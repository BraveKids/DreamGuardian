using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class DreamTwist : MonoBehaviour {
	private MotionBlur motionBlurScript;
	public Camera cam;
	// Use this for initialization
	void Start () {
		motionBlurScript = cam.GetComponent ("MotionBlur") as MotionBlur;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player") ) {
			if(motionBlurScript.enabled == false){
				motionBlurScript.enabled = true;
		}else{
				motionBlurScript.enabled = false;
			}

		
	}
}
}
