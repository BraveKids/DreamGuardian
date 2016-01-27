using UnityEngine;
using System.Collections;

public class skipTrailer : MonoBehaviour {


	void Start(){
		((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
	}
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Joystick1Button7)) {
			Application.LoadLevel("Gameplay");
		}

	}
}
