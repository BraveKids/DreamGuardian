using UnityEngine;
using System.Collections;

public class KnightBossScript : MonoBehaviour {
	public bool chase;
	public bool stun;
	public float stunTimer;
	public bool crashOnWall;
	public GameObject Trigger;
	bool vulnerable;
	bool left;
	Rigidbody2D rb;
	public Transform startPosition;
	public GameObject leftWall;
	public GameObject rightWall;
	GameObject player;
	public float moveSpeed = 4f;
	// Use this for initialization
	void Start () {
		crashOnWall = false;
		rb = GetComponentInParent<Rigidbody2D> ();
		stunTimer = 0f;
		stun = false;
		chase = true;
		left = true;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (chase) {
			if(left){
				rb.MovePosition(Vector3.MoveTowards (transform.position, new Vector3 (leftWall.transform.position.x, transform.position.y, leftWall.transform.position.z), Time.deltaTime * moveSpeed));
			}else{
				rb.MovePosition(Vector3.MoveTowards (transform.position, new Vector3 (rightWall.transform.position.x, transform.position.y, rightWall.transform.position.z), Time.deltaTime * moveSpeed));
			
			}
		}

		if (stun) {
			vulnerable = true;
			stunTimer += Time.deltaTime;
		}

		if (stunTimer >= 5f) {
			stunTimer = 0;
			BackOnHorse();
		}
	}
	

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Wall")) {
			if(crashOnWall){
			stun = true;
			chase = false;
			}else{

				ContinueChase();
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

	void BackOnHorse(){
		stun = false;
		Flip ();
		crashOnWall = false;
		vulnerable = false;
		if (left == true) {
			left = false;
		} else {
			left = true;
		}
		chase = true;
	}

	void ContinueChase(){

		if (left == true) {
			left = false;
		} else {
			left = true;
		}
		chase = true;
		Flip ();
	}
}
