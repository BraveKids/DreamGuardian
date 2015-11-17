using UnityEngine;
using System.Collections;
using System;

public class PlayerGroundOnPlatform : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D other) {

		if (other.CompareTag ("Platform")) {
		
			CameraFollowOnPlatform.instance.nextY = transform.position.y;
			Debug.Log("Platform");
		}

		if (other.CompareTag ("Ground")) {
			
			CameraFollowOnPlatform.instance.currentY = transform.position.y+CameraFollowOnPlatform.instance.groundDim;
			CameraFollowOnPlatform.instance.nextY = transform.position.y+CameraFollowOnPlatform.instance.groundDim;
			Debug.Log("Ground");
			
			
		}


	}


}
