using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class DreamTwistSpinCamera : MonoBehaviour {
	
	GameObject cam;
	// Use this for initialization
	void Start () {
		cam = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player") ) {
			cam.transform.Rotate(new Vector3(0,180f,180f));

			cam.transform.position = new Vector3(0,0, -cam.transform.position.z);
			this.gameObject.SetActive(false);
				
		}
		
		
		
	}
}
