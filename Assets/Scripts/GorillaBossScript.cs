using UnityEngine;
using System.Collections;

public class GorillaBossScript : MonoBehaviour {
	Rigidbody2D rb;
	public Animator anim;
	bool vulnerable;
	bool movingBack;
	bool canAttack;
	public bool grounded;	
	public bool active;
	public float stunTimer;
	public GameObject enemy;
	public GameObject[] ropes;
	public float moveSpeed;
	int actualRope;
	public int hp;
	public GameObject body;
	public int hpDelta;
	public float shootInterval;
	public float bulletSpeed = 10;
	public float bulletTimer;
	private CharacterControllerScript playerScript;
	GameObject player;

	public bool awake = false;
	public bool lookingRight;
	public GameObject bullet;
	public Transform target;
	public Transform shootPointLeft;
	public Transform shootPointRight;
	// Use this for initialization
	void Start () {


		active = false;
		grounded = false;
		player = GameObject.FindGameObjectWithTag("Player");
		playerScript = player.gameObject.GetComponent("CharacterControllerScript") as CharacterControllerScript;
		actualRope = 0;
		rb = GetComponent<Rigidbody2D>();
		rb.isKinematic = true;
		vulnerable = false;
		hp = 12;
		hpDelta = 0;
		canAttack = true;
		anim = GetComponentInChildren<Animator> ();
		anim.SetBool ("attack", active);
	
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {

			//anim.gameObject.SetActive(true);
			if (!ropes [actualRope].activeSelf == true) {
				rb.isKinematic = false;
				anim.Play("Falling");
				vulnerable = true;
				canAttack = false;
				actualRope += 1;
			}
			if (vulnerable) {

				stunTimer += Time.deltaTime;
				if(grounded){
					anim.Play ("Stun");
				}
			}

			if ((lookingRight == false && target.transform.position.x < transform.position.x) || (lookingRight == true && target.transform.position.x > transform.position.x)) {
				anim.SetBool("attack", false);
				Flip ();
			}


			if (canAttack) {
				Attack (lookingRight);
			}

			if (hpDelta == 4 || stunTimer >= 5f && hp>0) {
				BackToRope ();
				stunTimer = 0f;
				grounded = false;
			}

			if (movingBack == true) {
				anim.Play ("Jump");
				gameObject.transform.position = Vector3.MoveTowards (transform.position, ropes [actualRope].transform.position, Time.deltaTime * moveSpeed);
				bulletTimer = 0f;

			}
			if (transform.position.Equals (ropes [actualRope].transform.position)) {
				anim.SetBool("attack", true);
				movingBack = false;
				canAttack = true;
				anim.SetTrigger("backOnRope");

			}
		}
		if(hp<=0){
			anim.Play("Die");
			Invoke ("Death", 0.8f);
			
		}
}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("AttackTrigger") && vulnerable == true){
			hp-=1;
			anim.Play("damage");
			hpDelta+=1;
			if (playerScript.energy < 10)
			{
				playerScript.energy += 1;
				GameObject.Find("HUD").GetComponent<HUDManager>().updateMP(playerScript.energy);
			}

		}
	}
	


	void BackToRope(){
		anim.Play ("recover");
		bulletTimer = 0f;
		hpDelta=0;
		vulnerable = false;
		rb.isKinematic = true;
		Invoke ("MovingBack", 1f);
	}

	void Flip()
	{
		lookingRight = !lookingRight;
		Vector3 theScale = body.transform.localScale;
		theScale.x *= -1;
		body.transform.localScale = theScale;
		anim.SetBool("attack", true);
		//bulletTimer = 0f;
	}


	public void Attack (bool attackingRight)
	{
		bulletTimer += Time.deltaTime;
		if(bulletTimer >= shootInterval)
		{
			Vector2 direction = target.transform.position - transform.position;
			direction.Normalize();
			if (attackingRight)
			{
				GameObject bulletClone;
				bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation)as GameObject;
				bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
				bulletTimer = 0;
			}
			if (!attackingRight)
			{
				GameObject bulletClone;
				bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
				bulletTimer = 0;
			}
		}
	}

	void MovingBack(){
		movingBack = true;
	}

	void Death(){
		enemy.gameObject.SetActive(false);
	}


}
