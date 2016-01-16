using UnityEngine;
using System.Collections;

public class RunYumeRun : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.CompareTag ("Player")) {
			if (CameraFollowOnPlatform.instance.getChasingCamera ()) {
				Camera.main.transform.FindChild ("cameraBorder").gameObject.SetActive (false);
			}
			other.gameObject.GetComponent<CharacterControllerScript> ().runYumeRun ();
			CameraFollowOnPlatform.instance.setFollowYume (false);
		}		
	}
}
