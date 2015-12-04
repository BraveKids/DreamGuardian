﻿using UnityEngine;
using System.Collections;
using System;

public class PlayerGroundOnPlatform : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D other) {

		if (other.CompareTag ("Platform") || other.CompareTag ("MovingPlatform") ) {
		
			CameraFollowOnPlatform.instance.nextY = transform.position.y;

		}

		if (other.CompareTag ("Ground")) {
			
			//
			//CameraFollowOnPlatform.instance.currentY = transform.position.y+CameraFollowOnPlatform.instance.groundDim;
			//CameraFollowOnPlatform.instance.nextY = CameraFollowOnPlatform.instance.currentY+CameraFollowOnPlatform.instance.groundDim;

			
			
		}


	}


}
