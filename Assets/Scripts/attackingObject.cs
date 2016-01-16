using UnityEngine;
using System.Collections;

public class attackingObject : MonoBehaviour {
	Rigidbody2D rb;
	public Collider2D trigger;
	public float force = -300f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			trigger.gameObject.SetActive(false);
			rb.AddForce(new Vector2(force,0));;
			Invoke("Destroy", 3f);
		}
	}
	
	void Destroy(){
		this.gameObject.SetActive (false);
	}
}
