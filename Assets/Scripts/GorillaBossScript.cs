using UnityEngine;
using System.Collections;

public class GorillaBossScript : MonoBehaviour {
	Rigidbody2D rb;
	Animator anim;
	bool vulnerable;
	public GameObject enemy;
	public GameObject[] ropes;
	int actualRope;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.isKinematic = true;
		vulnerable = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(ropes[actualRope].activeSelf == false){
			rb.isKinematic = false;
			vulnerable = true;
			actualRope++;
	
	}
}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("AttackTrigger") && vulnerable == true){
			enemy.gameObject.SetActive(false);


}
	}
}
