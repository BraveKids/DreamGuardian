using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class GorillaBossScript : MonoBehaviour {
	Rigidbody2D rb;
	public AudioSource deathSound;
	public AudioSource hitSound;
	public Animator anim;
	public bool onRope;
	public bool vulnerable;
	bool movingBack;
	bool canAttack;
	SpriteRenderer renderer;
	Color normalColor;
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
	//public Slider hpHUD;
	public bool awake = false;
	public bool lookingRight;
	public GameObject bullet;
	public Transform target;
	public Transform shootPointLeft;
	public Transform shootPointRight;
	// Use this for initialization
	void Start () {
		renderer = GetComponentInChildren<SpriteRenderer> ();
		normalColor = renderer.material.color;
		onRope = true;
		active = false;
		grounded = false;
		player = GameObject.FindGameObjectWithTag("Player");
		playerScript = player.gameObject.GetComponent("CharacterControllerScript") as CharacterControllerScript;
		actualRope = 0;
		rb = GetComponent<Rigidbody2D>();
		rb.isKinematic = true;
		vulnerable = false;
		hp = 12;
		//GameObject.Find ("HUD").GetComponent<HUDManager> ().updateBossHP (hp);
		hpDelta = 0;
		canAttack = true;
		anim = GetComponentInChildren<Animator> ();
		anim.SetBool ("attack", active);
	
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			GameObject.Find ("HUD").GetComponent<HUDManager> ().gorillaBossHP.gameObject.SetActive (true);

			//anim.gameObject.SetActive(true);
			if (!ropes [actualRope].activeSelf == true || actualRope>4) {
				onRope = false;
				rb.isKinematic = false;
				body.gameObject.tag = "EnemyBody";
				anim.Play("Falling");
				vulnerable = true;
				canAttack = false;
				actualRope += 1;
			}
			if (vulnerable) {

				stunTimer += Time.deltaTime;
				if(grounded){
					anim.SetBool("stun",true);

				}
			}

			if ((lookingRight == false && target.transform.position.x < transform.position.x) || (lookingRight == true && target.transform.position.x > transform.position.x) && vulnerable == false) {
				anim.SetBool("attack", false);
				Flip ();
			}


			if (canAttack) {
				Attack (lookingRight);
			}

			if (hpDelta == 4 || stunTimer >= 5f) {
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
				onRope = true;
				anim.SetBool("attack", true);
				body.gameObject.tag = "Enemy";
				movingBack = false;
				canAttack = true;
				anim.SetTrigger("backOnRope");

			}
			if(hp<=0){
				deathSound.PlayOneShot(deathSound.clip);
				anim.SetTrigger("die");
				Invoke ("Death", 0.8f);
				
			}
		}

}

	IEnumerator DamageCoroutine(){
		Debug.Log ("Flash");
		renderer.material.color = Color.red;
		yield return new WaitForSeconds(0.1f);
		renderer.material.color = normalColor;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("AttackTrigger") && vulnerable == true && hp>0){
			hp-=1;
			hitSound.PlayOneShot(deathSound.clip);
			StartCoroutine("DamageCoroutine");
			GameObject.Find ("HUD").GetComponent<HUDManager> ().updateBossHP (hp);
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
		anim.SetBool ("stun", false);
		anim.Play ("recover");
		bulletTimer = 0f;
		hpDelta=0;
		vulnerable = false;
		rb.isKinematic = true;
		Invoke ("MovingBack", 1f);
	}

	void Flip()
	{
		if (onRope) {
			lookingRight = !lookingRight;
			Vector3 theScale = body.transform.localScale;
			theScale.x *= -1;
			body.transform.localScale = theScale;
			anim.SetBool ("attack", true);
			//bulletTimer = 0f;
		}
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
	/*
	public void updateHP (int hp) {
		hpHUD.value = hp;
	}*/

	void Death(){
		GameObject.Find ("HUD").GetComponent<HUDManager> ().gorillaBossHP.gameObject.SetActive (false);
		enemy.gameObject.SetActive(false);
	}


}
