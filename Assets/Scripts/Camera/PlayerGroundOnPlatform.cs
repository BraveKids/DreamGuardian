using UnityEngine;
using System.Collections;
using System;

public class PlayerGroundOnPlatform : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D other) {
		float nextY = transform.position.y;

		if (other.CompareTag ("Platform")) {


				//StartCoroutine (CameraFollowOnPlatform.instance.ResetCamera (transform.position.y, false));
			
			CameraFollowOnPlatform.instance.followMe(nextY, false);
			
			//CameraFollowOnPlatform.instance.nextY = transform.position.y;
			//CameraFollowOnPlatform.instance.isFalling = false;
		}

		if (other.CompareTag ("MovingPlatform")) {

			CameraFollowOnPlatform.instance.followMe(nextY, true);
			//StartCoroutine (CameraFollowOnPlatform.instance.ResetCamera (transform.position.y, true));

			//CameraFollowOnPlatform.instance.isFalling = false;
			
		}


		if (other.CompareTag ("Ground")) {

			CameraFollowOnPlatform.instance.originY = transform.position.y;
			CameraFollowOnPlatform.instance.nextY = transform.position.y;
			//
			//CameraFollowOnPlatform.instance.currentY = transform.position.y+CameraFollowOnPlatform.instance.groundDim;
			//CameraFollowOnPlatform.instance.nextY = CameraFollowOnPlatform.instance.currentY+CameraFollowOnPlatform.instance.groundDim;

					
		}

		//CameraFollowOnPlatform.instance.isFalling = false;
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag ("MovingPlatform")) {
			CameraFollowOnPlatform.instance.diff_when_moving = 0;
			CameraFollowOnPlatform.instance.on_moving_plat = false;
			//CameraFollowOnPlatform.instance.currentY = transform.position.y;
		}
	}




}



