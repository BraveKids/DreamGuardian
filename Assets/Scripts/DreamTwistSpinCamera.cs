using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class DreamTwistSpinCamera : MonoBehaviour {
	
	public Camera cam;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player") ) {
			cam.transform.Rotate(new Vector3(0,180,180));
			cam.transform.Translate(0,0,-20);
			this.gameObject.SetActive(false);
				
		}
		
		
		
	}
}
