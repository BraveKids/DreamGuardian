using UnityEngine;
using System.Collections;
using System;

public class PlayerGroundOnPlatform : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D other) {
		float nextY = transform.position.y;

		if (other.CompareTag ("Platform")) {


<<<<<<< HEAD
				//StartCoroutine (CameraFollowOnPlatform.instance.ResetCamera (transform.position.y, false));
			
			CameraFollowOnPlatform.instance.followMe(nextY, false);
=======
			//StartCoroutine (CameraFollowOnPlatform.instance.ResetCamera (transform.position.y, false));
			
			CameraFollowOnPlatform.instance.followMe (nextY, false);
>>>>>>> camera_follow
			
			//CameraFollowOnPlatform.instance.nextY = transform.position.y;
			//CameraFollowOnPlatform.instance.isFalling = false;
		}

		if (other.CompareTag ("MovingPlatform")) {
			Debug.Log ("entered");
			//other.gameObject.GetComponentInChildren<BoxCollider2D> ().enabled = true;
			other.transform.GetChild (0).GetComponent<BoxCollider2D> ().enabled = true;

<<<<<<< HEAD
			CameraFollowOnPlatform.instance.followMe(nextY, true);
=======
			CameraFollowOnPlatform.instance.followMe (nextY, true);
>>>>>>> camera_follow
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
		if (other.CompareTag ("MovingPlatformExt")) {
			CameraFollowOnPlatform.instance.diff_when_moving = 0;
			CameraFollowOnPlatform.instance.onMovingPlat = false;
			//other.transform.GetChild (0).GetComponent<BoxCollider2D> ().enabled = false;
			other.enabled = false;
			//CameraFollowOnPlatform.instance.currentY = transform.position.y;
		}
	}

	/*void OnTriggerStay2D(Collider2D other){
		if(other.CompareTag("MovingPlatform")){
			CameraFollowOnPlatform.instance.followMe(transform.position.y, false);
		}
	}*/






}



