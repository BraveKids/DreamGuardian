using UnityEngine;
using System.Collections;

public class GorillaBossScript : MonoBehaviour {
	Rigidbody2D rb;
	Animator anim;
	bool vulnerable;
	bool movingBack;
	public GameObject enemy;
	public GameObject[] ropes;
	public float moveSpeed;
	int actualRope;
	int hp;
	public int hpDelta;
	// Use this for initialization
	void Start () {
		actualRope = 0;
		rb = GetComponent<Rigidbody2D>();
		rb.isKinematic = true;
		vulnerable = false;
		hp = 12;
		hpDelta = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (hpDelta);

		if(!ropes[actualRope].activeSelf==true){
			rb.isKinematic = false;
			vulnerable = true;
			actualRope+=1;
		

			

	}
		if (hpDelta == 4) {
			BackToRope();
			}
		if (movingBack == true) {
			gameObject.transform.position = Vector3.MoveTowards (transform.position,ropes [actualRope].transform.position,  Time.deltaTime * moveSpeed);

		}
		if (transform.position.Equals(ropes [actualRope].transform.position)) {
			movingBack = false;
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
}
