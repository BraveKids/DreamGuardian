using UnityEngine;
using System.Collections;

public class VerticalLevel : MonoBehaviour {

	public bool vertical;
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {

			CameraFollowOnPlatform.instance.verticalLevel(vertical);
		}
	}
}
