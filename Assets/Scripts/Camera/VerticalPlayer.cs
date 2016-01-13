using UnityEngine;
using System.Collections;
using System;

public class VerticalPlayer : MonoBehaviour {
	
	
	void OnTriggerEnter2D (Collider2D other) {
		float nextY = transform.position.y;
		
		if (other.CompareTag ("Platform")) {
			
			//StartCoroutine (CameraFollowOnPlatform.instance.ResetCamera (transform.position.y, false));
			
			VerticalCamera.instance.followMe (nextY, false);
			
			
			//CameraFollowOnPlatform.instance.nextY = transform.position.y;
			//CameraFollowOnPlatform.instance.isFalling = false;
		}
		
		if (other.CompareTag ("MovingPlatform")) {
			//other.gameObject.GetComponentInChildren<BoxCollider2D> ().enabled = true;
			other.transform.GetChild (0).GetComponent<BoxCollider2D> ().enabled = true;
			
			
			
			VerticalCamera.instance.followMe (nextY, true);
			
			//StartCoroutine (CameraFollowOnPlatform.instance.ResetCamera (transform.position.y, true));
			
			//CameraFollowOnPlatform.instance.isFalling = false;
			
		}
		
		
		if (other.CompareTag ("Ground")) {
			
			VerticalCamera.instance.originY = transform.position.y;
			VerticalCamera.instance.nextY = transform.position.y;
			//
			//CameraFollowOnPlatform.instance.currentY = transform.position.y+CameraFollowOnPlatform.instance.groundDim;
			//CameraFollowOnPlatform.instance.nextY = CameraFollowOnPlatform.instance.currentY+CameraFollowOnPlatform.instance.groundDim;
			
			
		}
		
		//CameraFollowOnPlatform.instance.isFalling = false;
	}
	
	void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag ("MovingPlatformExt")) {
			VerticalCamera.instance.diff_when_moving = 0;
			VerticalCamera.instance.onMovingPlat = false;
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



