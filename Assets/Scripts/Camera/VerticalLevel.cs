using UnityEngine;
using System.Collections;

public class VerticalLevel : MonoBehaviour {

	public bool vertical;
	public bool dreamTwist;
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			CameraFollowOnPlatform.instance.verticalLevel (vertical);
			CameraFollowOnPlatform.instance.dreamTwist (dreamTwist);
		}
	}
}
