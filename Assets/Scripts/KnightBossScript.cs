using UnityEngine;
using System.Collections;

public class KnightBossScript : MonoBehaviour {
	public AudioSource deathSound;
	public AudioSource hitSound;
	public AudioSource wallSound;
	public AudioSource horseRunning;
	public AudioClip neigh;
	public AudioClip roar;
	public bool chase;
	public bool active;
	public bool stun;
	public bool freeRound;
	public float stunTimer;
	public bool crashOnWall;
	public GameObject Trigger;
	public Transform tooLateLeftPoint;
	public Transform tooLateRightPoint;
	public bool tooLate;
	public GameObject enemy;
	public int hp;
	public Animator anim;
	SpriteRenderer renderer;
	Color normalColor;
	public int hpDelta;
	public bool left;
	Rigidbody2D rb;
	public GameObject attackTrigger;
	public Transform startPosition;
	public GameObject leftWall;
	public GameObject rightWall;
	GameObject player;
	public float moveSpeed = 4f;
	private CharacterControllerScript playerScript;
	// Use this for initialization
	void Start () {
		hp = 12;
		anim = GetComponent<Animator> ();
		renderer = GetComponent<SpriteRenderer> ();
		normalColor = renderer.material.color;
		hpDelta = 0;
		player = GameObject.FindGameObjectWithTag("Player");
		playerScript = player.gameObject.GetComponent("CharacterControllerScript") as CharacterControllerScript;
		crashOnWall = false;
		rb = GetComponentInParent<Rigidbody2D> ();
		stunTimer = 0f;
		stun = false;
		chase = true;
		left = true;
		tooLate = false;
		freeRound = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			GameObject.Find ("HUD").GetComponent<HUDManager> ().knightBossHP.gameObject.SetActive (true);
			if (chase) {
				if(!horseRunning.isPlaying){
					horseRunning.PlayOneShot(horseRunning.clip);
				}
				if (left) {

					rb.MovePosition (Vector3.MoveTowards (transform.position, new Vector3 (leftWall.transform.position.x, transform.position.y, leftWall.transform.position.z), Time.deltaTime * moveSpeed));
				} else {

					rb.MovePosition (Vector3.MoveTowards (transform.position, new Vector3 (rightWall.transform.position.x, transform.position.y, rightWall.transform.position.z), Time.deltaTime * moveSpeed));
			
				}
			}

			CheckTooLateToStop ();

			if (stun) {
				anim.SetBool("stun", true);
				attackTrigger.gameObject.SetActive(false);
				gameObject.tag = "EnemyBody" +
					"";
				stunTimer += Time.deltaTime;
			}

			if ((stunTimer >= 5f || hpDelta == 4) && hp>0) {
				anim.SetBool("stun", false);
				stunTimer = 0f;
				hpDelta = 0;
				stun = false;
				//anim.SetTrigger ("flip");
				Flip ();
				hitSound.PlayOneShot(neigh);
				deathSound.PlayOneShot(roar);
				anim.SetTrigger("rampage");
				Invoke("BackOnHorse", 1.2f);
				}

			if(hp==0){
				anim.SetTrigger("die");
				Invoke ("Death", 1f);
			}
			
		}
	}

	IEnumerator DamageCoroutine(){
		Debug.Log ("Flash");
		renderer.material.color = Color.red;
		yield return new WaitForSeconds(0.1f);
		renderer.material.color = normalColor;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Wall")) {
			if(crashOnWall && !freeRound){
				horseRunning.Stop();
				wallSound.PlayOneShot(wallSound.clip);
				anim.Play("crash");
				stun = true;
				chase = false;
			
			}else{

				ContinueChase();
				freeRound = false;
			}
		}
		if (other.CompareTag("AttackTrigger") && stun == true && hp>0 && hpDelta<4){
			hp-=1;
			hitSound.PlayOneShot(deathSound.clip);
			StartCoroutine("DamageCoroutine");
			GameObject.Find ("HUD").GetComponent<HUDManager> ().updateKnightBossHP (hp);
			hpDelta+=1;

			if (playerScript.energy < 10)
			{
				playerScript.energy += 1;
				GameObject.Find("HUD").GetComponent<HUDManager>().updateMP(playerScript.energy);
			}

		}



	}

	void Flip()
	{

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		Vector3 triggerScale = Trigger.transform.localScale;
		triggerScale.x *= -1;
		Trigger.transform.localScale = triggerScale;

	}

	void CheckTooLateToStop(){
			if(left && (transform.position.x < tooLateLeftPoint.position.x)){
				tooLate = true;
			}else{
			if( !left && transform.position.x > tooLateRightPoint.position.x){
				tooLate = true;
			}
		}
		 
	}
	void Death(){
		GameObject.Find ("HUD").GetComponent<HUDManager> ().knightBossHP.gameObject.SetActive (false);
		enemy.gameObject.SetActive(false);
	}
	
	public void moveBackToStart(){
		ContinueChase ();
		freeRound = true;
	}

	void BackOnHorse(){
		attackTrigger.gameObject.SetActive(true);
		gameObject.tag = "Enemy";
		tooLate = false;
		crashOnWall = false;
		if (left == true) {
			left = false;
		} else {
			left = true;
		}
		chase = true;
	}

	void ContinueChase(){
		tooLate = false;
		crashOnWall = false;
		if (left == true) {
			left = false;
		} else if(left == false) {
			left = true;
		}
		chase = true;
		Flip ();
	}
}
