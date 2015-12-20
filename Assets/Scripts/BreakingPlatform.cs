using UnityEngine;
using System.Collections;

public class BreakingPlatform : MonoBehaviour {
	public GameObject parent;
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			Debug.Log ("ATTENTO");
			Invoke ("DestroyPlatform", 0.8f);
			Invoke ("RegeneratePlatform", 3f);
		}

		
	}

	void DestroyPlatform(){
		parent.SetActive (false);
	}

	void RegeneratePlatform(){
		parent.SetActive (true);
	}

}
