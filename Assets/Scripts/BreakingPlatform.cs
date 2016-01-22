using UnityEngine;
using System.Collections;

public class BreakingPlatform : MonoBehaviour {
	public GameObject parent;
	Rigidbody2D rb;
	public GameObject sprite;
	Vector3 startPosition;
	bool Up;
	bool shake;
	void Start(){
		startPosition = new Vector3 (parent.transform.position.x, parent.transform.position.y, parent.transform.position.z);
		Up = true;
		rb = parent.GetComponent<Rigidbody2D> ();
		rb.isKinematic = true;
		shake = false;

	}

	void Update(){
		if (shake) {
			if (Up) {
				sprite.gameObject.transform.Translate (0, 0.05f, 0);
				Up = false;
			} else {
				sprite.gameObject.transform.Translate (0, -0.05f, 0);
				Up = true;
			}
		}
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			shake = true;
			Debug.Log ("ATTENTO");
			Invoke ("Fall", 0.8f);
			Invoke ("RegeneratePlatform", 3f);
		}
		if (other.CompareTag("Ground")){
			DestroyPlatform();
		}

		
	}

	void Fall(){
		shake = false;
		rb.isKinematic = false;
	}

	void DestroyPlatform(){
		parent.SetActive (false);
	}

	void RegeneratePlatform(){
		shake = false;
		parent.transform.position = startPosition;
		rb.isKinematic = true;
		parent.SetActive (true);
	}

}
