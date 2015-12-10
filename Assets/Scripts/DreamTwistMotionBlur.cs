using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class DreamTwistMotionBlur : MonoBehaviour {
	private MotionBlur motionBlurScript;
	 GameObject cam;
	// Use this for initialization
	void Start () {
		cam = GameObject.FindGameObjectWithTag("MainCamera");
		motionBlurScript = cam.GetComponent ("MotionBlur") as MotionBlur;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player") ) {
			if(motionBlurScript.enabled == false){
				motionBlurScript.enabled = true;
				this.gameObject.SetActive(false);
		}else{
				motionBlurScript.enabled = false;
				this.gameObject.SetActive(false);
			}

		
	}
}
}
