using UnityEngine;
using System.Collections;

public class fallingObject : MonoBehaviour {
	Rigidbody2D rb;
	public Collider2D trigger;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			rb.isKinematic = false;
			Invoke("Destroy", 0.8f);
			}
		}

	void Destroy(){
		this.gameObject.SetActive (false);
	}
}
