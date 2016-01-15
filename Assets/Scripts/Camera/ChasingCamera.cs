using UnityEngine;
using System.Collections;

public class ChasingCamera : MonoBehaviour {

	public bool chasing;

	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.CompareTag ("Player")) {
			CameraFollowOnPlatform.instance.setChasingCamera (chasing);
		}
	}
}
