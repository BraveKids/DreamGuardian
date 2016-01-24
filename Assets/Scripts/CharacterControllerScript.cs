using UnityEngine;
using System.Collections;

public class CharacterControllerScript : MonoBehaviour {

	public float maxSpeed;
	public int hp = 3;
	public int energy = 0;
	bool facingRight = true;
	Rigidbody2D rb;
	public float vMove;
	public Animator anim;
	public float arrowTimer;
	public bool canMove;
	public bool steso;
	private bool  runYume = false;
	SpriteRenderer renderer;
	Color normalColor;
	public GameObject colliderCrouch;
	public GameObject damageAreaStand;
	public GameObject damageAreaCrouch;
	public Collider2D attackTrigger1;
	public Collider2D attackTrigger2;
	public Collider2D attackTrigger3;
	public Collider2D attackJumpTrigger;
	public Collider2D superAttackTrigger;
	bool groundedLeft = false;
	bool groundedRight = false;
	bool grounded = false;
	public Transform groundCheckLeft;
	public Transform groundCheckRight;
	float hitDelay = 1f;
	private float nextHitAllowed = 0f;
	float groundRadius = 0.1f;
	public LayerMask whatIsGround; //cosa il character deve considerare ground es. il terreno, i nemici...
	public float jumpForce;
	public GameObject platform;
	public GameObject arrow;
	public Transform firePoint;
	public Transform platformSpwnPoint;
	private int abilitySelector = 0;	//an int used for circulary shift the skills
	private string abilitySelected;				//this is the ability selected
	// Use this for initialization
	void Awake () {
		canMove = true;
		steso = false;
		renderer = GetComponent<SpriteRenderer> ();
		normalColor = renderer.material.color;
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	
	// Update is called once per frame
	void Update () {

		arrowTimer += Time.deltaTime;
		ChangeAbility ();
		Ability ();
		Movement ();
		vMove = Input.GetAxis("Vertical");
		if (vMove<-0.9 && grounded && canMove ){
			steso = true;
			anim.SetBool("steso", true);
			anim.Play("YumeCrouch");
			rb.velocity = new Vector3 (0f, 0f, 0f);
			colliderCrouch.gameObject.SetActive(true);
			gameObject.GetComponent<PlayerAttack>().steso = true;
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
			gameObject.GetComponent<CircleCollider2D>().enabled = false;
			damageAreaStand.gameObject.SetActive(false);
			damageAreaCrouch.gameObject.SetActive(true);
		}else if (vMove>-1){
			steso = false;
			anim.SetBool("steso", false);
			gameObject.GetComponent<PlayerAttack>().steso = false;
			gameObject.GetComponent<BoxCollider2D>().enabled = true;
			gameObject.GetComponent<CircleCollider2D>().enabled = true;;
			damageAreaStand.gameObject.SetActive(true);
			damageAreaCrouch.gameObject.SetActive(false);
			colliderCrouch.gameObject.SetActive(false);
		}
	}

	void ChangeAbility () {
		int skillsUnlocked = SaveLoad.savedGame.skills.Count;

		if (skillsUnlocked > 0) {
			if (Input.GetKeyDown (KeyCode.Joystick1Button5) || Input.GetKeyDown (KeyCode.V)) {
				abilitySelector += 1;
				abilitySelector = abilitySelector % skillsUnlocked;

				abilitySelected = SaveLoad.savedGame.skills [abilitySelector];
				setAbility (SaveLoad.savedGame.skills [abilitySelector]);

				Debug.Log (abilitySelected);
			}
		}
	}

	void Ability () {
		if (energy > 0 && canMove && (Input.GetKeyDown (KeyCode.Joystick1Button1) || Input.GetKeyDown (KeyCode.G)) && anim.GetBool ("Ground") == true && !platform.activeSelf && abilitySelected == "platformAbility") {
			
			platform.transform.position = platformSpwnPoint.position;
			anim.Play ("YumePiattaforma");

			anim.SetBool ("platform", true);
			rb.velocity = new Vector3 (0f, 0f, 0f);
			Invoke ("PlatformAbility", 0.25f);
			energy -= 1;
			GameObject.Find ("HUD").GetComponent<HUDManager> ().updateMP (energy);
			Invoke ("PlatformAbilityClose", 3f);

		}




		if (energy > 0 && canMove && arrowTimer >= 1.3f && (Input.GetKeyDown (KeyCode.Joystick1Button1) || Input.GetKeyDown (KeyCode.G)) && !arrow.activeSelf && abilitySelected == "arrowAbility") {
			arrowTimer = 0f;
			arrow.transform.position = firePoint.position;
			if (anim.GetBool ("Ground") == false) {
				anim.Play ("YumeArcoSalto");
			} else {
				anim.Play ("YumeArcoTerra");
			}

			rb.velocity = new Vector3 (0f, rb.velocity.y, 0f);
			anim.SetBool ("shooting", true);
			Invoke ("ArrowAbility", 0.1f);
			Invoke ("ArrowAbilityClose", 1.2f);
			energy -= 2;
			GameObject.Find ("HUD").GetComponent<HUDManager> ().updateMP (energy);

		}
	}

	void Movement () {
		/*
		if (Input.GetKeyDown (KeyCode.H)) {
			anim.Play("respawn");
		}
		if (Input.GetKeyDown (KeyCode.J)) {
			anim.Play("flare");
		}	
		*/
		if (!steso && canMove && grounded && anim.GetBool ("Attacking") == false && (Input.GetKeyDown (KeyCode.Joystick1Button0) || Input.GetKeyDown (KeyCode.Space)) && anim.GetFloat("vSpeed")<=0) {
			anim.SetBool ("Ground", false);
			rb.AddForce (new Vector2 (0, jumpForce));
		}
		
		if (!steso && canMove && anim.GetBool ("Attacking") == false && anim.GetBool ("shooting") == false && anim.GetBool ("IstantDeath") == false && anim.GetBool ("platform") == false) {
			groundedLeft = Physics2D.OverlapCircle (groundCheckLeft.position, groundRadius, whatIsGround);
			groundedRight = Physics2D.OverlapCircle (groundCheckRight.position, groundRadius, whatIsGround);
			grounded = groundedLeft || groundedRight;
			anim.SetBool ("Ground", grounded); //per "capire" se è o no grounded, continua a chiederselo/ a verificarlo
			
			anim.SetFloat ("vSpeed", rb.velocity.y); //vertical speed

			float move = Input.GetAxis ("Horizontal");

			anim.SetFloat ("Speed", Mathf.Abs (move)); //con questa riga risco a "leggere" il mutamento di Speed
			// e quindi a far cambiare l'animazione da idle a run
			
			rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);

			if (move > 0 && !facingRight) {
				Flip ();
			} else if (move < 0 && facingRight) {
				Flip ();
			}
		}

		if (runYume) {
			float move = 1;
			anim.SetFloat ("Speed", Mathf.Abs (move)); //con questa riga risco a "leggere" il mutamento di Speed
			// e quindi a far cambiare l'animazione da idle a run
			
			rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);
		}

	


	}

	void Flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	IEnumerator DamageCoroutine () {
		Debug.Log ("Flash");
		renderer.material.color = Color.red;
		yield return new WaitForSeconds (0.1f);
		renderer.material.color = normalColor;
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.CompareTag ("Enemy") && attackTrigger1.enabled == false && attackJumpTrigger.enabled == false && attackTrigger2.enabled == false && attackTrigger3.enabled == false && superAttackTrigger.enabled == false && Time.time > nextHitAllowed) {
			anim.Play ("YumeDamage");
			StartCoroutine ("DamageCoroutine");
			hp -= 1;
			GameObject.Find ("HUD").GetComponent<HUDManager> ().updateHP (hp);
			nextHitAllowed = Time.time + hitDelay;
			if (hp <= 0) {
				anim.SetTrigger ("death");
				Invoke ("Death", 0.6f);
			}
		}
	

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Death")) {
			anim.SetBool ("IstantDeath", true);
			rb.velocity = new Vector3 (0f, 0f, 0f);
			Invoke ("Death", 0.6f);
		}
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = other.transform;
		}
		if (other.CompareTag ("EnemyObject")) {
			anim.Play ("YumeDamage");
			StartCoroutine ("DamageCoroutine");
			hp -= 1;
			GameObject.Find ("HUD").GetComponent<HUDManager> ().updateHP (hp);
			nextHitAllowed = Time.time + hitDelay;
			if (hp <= 0) {
				anim.SetTrigger ("death");
				Invoke ("Death", 0.6f);
		
			}
			other.gameObject.SetActive (false);
		}
		if (other.CompareTag ("EnemyTrigger")&& Time.time > nextHitAllowed) {
			anim.Play ("YumeDamage");
			StartCoroutine("DamageCoroutine");
			hp -= 1;
			GameObject.Find ("HUD").GetComponent<HUDManager> ().updateHP (hp);
			nextHitAllowed = Time.time + hitDelay;
			if (hp <= 0) {
				anim.SetTrigger ("death");
				Invoke ("Death", 0.6f);
				
			}
			
		}
		
	}

	public void Death () {
		anim.SetBool ("IstantDeath", false);
		anim.SetTrigger ("respawn");
		Application.LoadLevel (Application.loadedLevel);	//level reset
		CameraFollowOnPlatform.instance.Start ();	//need to reobtain the player object
		GameObject.Find ("HUD").GetComponent<HUDManager> ().Start ();
		SaveLoad.Spawn ();
		hp = 3;
		energy = 3;
	}

	public void setAbility (string ability) {
		abilitySelected = ability;
		//to implement -> update the GUI
		GameObject.Find ("HUD").GetComponent<HUDManager> ().setAbilityHUD (ability);
	}

	public string getAbility () {
		return abilitySelected;
	}

	void PlatformAbility () {
		platform.SetActive (true);
		anim.SetBool ("platform", false);
	}

	void PlatformAbilityClose () {
		platform.SetActive (false);

	}

	void ArrowAbility () {
		arrow.SetActive (true);
		Rigidbody2D arrowRb = arrow.GetComponent<Rigidbody2D> ();
		if (facingRight == true) {
			arrowRb.AddForce (new Vector2 (400, 0));
			anim.SetBool ("shooting", false);
		} else {
			arrowRb.AddForce (new Vector2 (-400, 0));
			anim.SetBool ("shooting", false);
		}


	}

	void ArrowAbilityClose () {

		arrow.SetActive (false);
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = null;
		}
		
	}

	private void setCanMove (bool move) {
		this.canMove = move;
	}

	private void setRunYume (bool run) {
		this.runYume = run;
	}

	public void runYumeRun () {
		setCanMove (false);
		setRunYume (true);
	}

	public void stopRunYume () {
		setRunYume (false);
		setCanMove (true);
	}

	public void stopYume () {
		canMove = false;
		anim.SetFloat ("Speed", 0f);
		transform.gameObject.GetComponent<PlayerAttack> ().canAttack = false;
	}

	public void goYume () {
		canMove = true;
		transform.gameObject.GetComponent<PlayerAttack> ().canAttack = true;
	}
	
}
