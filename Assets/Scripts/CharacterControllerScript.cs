using UnityEngine;
using System.Collections;

public class CharacterControllerScript : MonoBehaviour {

    public float maxSpeed;
	public int hp = 3;

    bool facingRight = true;
   	Rigidbody2D rb;
    Animator anim;
	public Collider2D attackTrigger1;
	public Collider2D attackTrigger2;
	public Collider2D attackTrigger3;
	public Collider2D superAttackTrigger;
    bool groundedLeft = false;
	bool groundedRight = false;
	bool grounded = false;
	public Transform groundCheckLeft;
	public Transform groundCheckRight;
	float hitDelay = 1.5f;
	private float nextHitAllowed = 0f;
    float groundRadius = 0.1f;
    public LayerMask whatIsGround; //cosa il character deve considerare ground es. il terreno, i nemici...
	public float jumpForce;
	public GameObject platform;
	public GameObject arrow;
	public Transform firePoint;
	public Transform platformSpwnPoint;
	int abilitySelector = 0;

    // Use this for initialization
    void Awake () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


    }
	
	// Update is called once per frame
    void Update()
    {
		ChangeAbility ();
		Ability ();
		Movement ();


    }
	void ChangeAbility(){
		if (Input.GetKeyDown (KeyCode.Joystick1Button5)|| Input.GetKeyDown(KeyCode.V)) {
			if (abilitySelector == 0) {
				abilitySelector = 1;
				Debug.Log ("Abilità 2");
			} else {
				abilitySelector = 0;
				Debug.Log ("Abilità 1");
			}

		}
	}

	void Ability(){
		if ((Input.GetKeyDown (KeyCode.Joystick1Button1) || Input.GetKeyDown (KeyCode.G))  && anim.GetBool ("Ground") == true && !platform.activeSelf && abilitySelector==0) {
			

			platform.transform.position = platformSpwnPoint.position;
			anim.Play("YumePiattaforma");
			Invoke("PlatformAbility", 0.25f);
			Invoke ("PlatformAbilityClose", 3f);
		}
		if ((Input.GetKeyDown (KeyCode.Joystick1Button1) || Input.GetKeyDown (KeyCode.G)) && !arrow.activeSelf && abilitySelector==1 && anim.GetBool ("Ground") == true ) {

			arrow.transform.position = firePoint.position;
			anim.Play ("YumeArcoTerra");

			Invoke ("ArrowAbility", 0.25f);
			Invoke ("ArrowAbilityClose", 1.2f);
		}
	}

	void Movement(){

		if (grounded && (Input.GetKeyDown(KeyCode.Joystick1Button0)|| Input.GetKeyDown(KeyCode.Space)))
		{
			anim.SetBool("Ground", false);
			rb.AddForce(new Vector2(0, jumpForce));
		}
		
		if (anim.GetBool ("Attacking") == false) {
			groundedLeft = Physics2D.OverlapCircle (groundCheckLeft.position, groundRadius, whatIsGround);
			groundedRight = Physics2D.OverlapCircle (groundCheckRight.position, groundRadius, whatIsGround);
			grounded = groundedLeft || groundedRight;
			anim.SetBool ("Ground", grounded); //per "capire" se è o no grounded, continua a chiederselo/ a verificarlo
			
			anim.SetFloat ("vSpeed", rb.velocity.y); //vertical speed
			
			float move = Input.GetAxis ("Horizontal");
			anim.SetFloat ("Speed", Mathf.Abs (move)); //con questa riga risco a "leggere" il mutamento di Speed
			// e quindi a far cambiare l'animazione da idle a run
			
			rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);
			
			if (move > 0 && !facingRight)
				Flip ();
			else if (move < 0 && facingRight)
				Flip ();
		}

	


	}

	
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

	void OnTriggerStay2D(Collider2D other) {
		if (other.CompareTag ("Enemy") && attackTrigger1.enabled == false && attackTrigger2.enabled == false && attackTrigger3.enabled == false && superAttackTrigger.enabled== false && Time.time > nextHitAllowed) {

			hp -= 1;
			Debug.Log ("Danno " + hp + " left!");
			nextHitAllowed = Time.time + hitDelay;
			if (hp <= 0) {
				anim.SetTrigger ("death");
				Invoke ("Death", 0.8f);
			}
		}
		}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Death") ) {
			anim.SetTrigger ("IstantDeath");
			rb.isKinematic = true;
			Invoke("Death",0.3f);
		}
		if (other.transform.tag == "MovingPlatform" ) {
			transform.parent = other.transform;
		}
		if(other.CompareTag("EnemyObject")){
			hp -= 1;
			Debug.Log ("Danno " + hp + " left!");
			nextHitAllowed = Time.time + hitDelay;
			if (hp <= 0) {
				anim.SetTrigger ("death");
				Invoke ("Death", 0.8f);
		
		}
			other.gameObject.SetActive(false);
		}
		
	}
	
	 void Death(){
		this.gameObject.SetActive (false);

	}

	void PlatformAbility(){
		platform.SetActive(true);
	}

	void PlatformAbilityClose(){
		platform.SetActive (false);
	}

	
	void ArrowAbility(){
		arrow.SetActive(true);
		Rigidbody2D arrowRb = arrow.GetComponent<Rigidbody2D>();
		if(facingRight==true){
			arrowRb.AddForce(new Vector2(400,0));
		}else{
			arrowRb.AddForce(new Vector2(-400,0));
		}
	}


	void ArrowAbilityClose(){
		arrow.SetActive (false);
	}



	void OnTriggerExit2D(Collider2D other){
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = null;
		}
		
	}
}
