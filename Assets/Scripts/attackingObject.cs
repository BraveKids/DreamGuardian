using UnityEngine;
using System.Collections;

public class attackingObject : MonoBehaviour {
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
			rb.AddForce(new Vector2(-400,0));;
			Invoke("Destroy", 3f);
		}
	}
	
	void Destroy(){
		this.gameObject.SetActive (false);
	}
}
