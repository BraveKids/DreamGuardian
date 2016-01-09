using UnityEngine;
using System.Collections;

public class RunYumeRun : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.CompareTag ("Player")) {
			other.gameObject.GetComponent<CharacterControllerScript>().runYumeRun();
			CameraFollowOnPlatform.instance.setFollowYume(false);
		}		
	}
}
