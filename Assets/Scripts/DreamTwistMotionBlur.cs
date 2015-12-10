using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class DreamTwistMotionBlur : MonoBehaviour {
	private MotionBlur motionBlurScript;
	private CameraMotionBlur cameraMotionBlurScript;
	public Camera cam;
	// Use this for initialization
	void Start () {
		motionBlurScript = cam.GetComponent ("MotionBlur") as MotionBlur;
		cameraMotionBlurScript = cam.GetComponent ("CameraMotionBlur") as CameraMotionBlur;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player") ) {
			if(motionBlurScript.enabled == false){
				motionBlurScript.enabled = true;
				cameraMotionBlurScript.enabled = true;
				this.gameObject.SetActive(false);
		}else{
				motionBlurScript.enabled = false;
				cameraMotionBlurScript.enabled = false;
				this.gameObject.SetActive(false);

			}

		
	}
}
}
