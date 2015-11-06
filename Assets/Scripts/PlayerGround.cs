using UnityEngine;
using System.Collections;
using System;

public class PlayerGround : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D other) {

		if (other.CompareTag ("Ground")) {


			//CameraFollowFromMid.instance.origin= new Vector3(transform.position.x, transform.position.y, transform.position.z);
			CameraFollowOnPlatform.instance.nextOrigin.x=transform.position.x;
			CameraFollowOnPlatform.instance.nextOrigin.y=transform.position.y;
			

		}
	}


}
