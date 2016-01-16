using UnityEngine;
using System.Collections;

public class fallingplatformScript : MonoBehaviour {
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponentInParent<Rigidbody2D> ();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("AttackTrigger")){
			this.gameObject.SetActive(false);
			rb.isKinematic = false;
	}
}
}
