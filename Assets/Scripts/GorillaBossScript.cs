using UnityEngine;
using System.Collections;

public class GorillaBossScript : MonoBehaviour {
	Rigidbody2D rb;
	Animator anim;
	bool vulnerable;
	bool movingBack;
	bool canAttack;
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
	
	public bool awake = false;
	public bool lookingRight;
	
	public GameObject bullet;
	public Transform target;
	public Transform shootPointLeft;
	public Transform shootPointRight;
	// Use this for initialization
	void Start () {
		actualRope = 0;
		rb = GetComponent<Rigidbody2D>();
		rb.isKinematic = true;
		vulnerable = false;
		canAttack = true;
		hp = 12;
		hpDelta = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (hpDelta);

		if(!ropes[actualRope].activeSelf==true){
			rb.isKinematic = false;
			vulnerable = true;
			canAttack = false;
			actualRope+=1;
			}
		/*if (target.transform.position.x > transform.position.x)
		{
			lookingRight = true;

		}
		if (target.transform.position.x < transform.position.x)
		{
			lookingRight = false;

		}*/
		if (vulnerable) {
			stunTimer += Time.deltaTime;
		}

		if ((lookingRight == false && target.transform.position.x < transform.position.x)|| (lookingRight == true && target.transform.position.x > transform.position.x))
		{
			Flip();
		}


		if (canAttack) {
			Attack (lookingRight);
		}

		if (hpDelta == 4 || stunTimer>=5f) {
			BackToRope();
			stunTimer=0f;
			}

		if (movingBack == true) {
			gameObject.transform.position = Vector3.MoveTowards (transform.position,ropes [actualRope].transform.position,  Time.deltaTime * moveSpeed);

		}
		if (transform.position.Equals(ropes [actualRope].transform.position)) {
			movingBack = false;
			canAttack = true;
		}
}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("AttackTrigger") && vulnerable == true){
			hp-=1;
			hpDelta+=1;
			if(hp<=0){
			enemy.gameObject.SetActive(false);
			}
		}
	}




	void BackToRope(){
		hpDelta=0;
		vulnerable = false;
		rb.isKinematic = true;
		movingBack = true;
	}

	void Flip()
	{
		lookingRight = !lookingRight;
		Vector3 theScale = body.transform.localScale;
		theScale.x *= -1;
		body.transform.localScale = theScale;
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
}
