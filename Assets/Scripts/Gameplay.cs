using UnityEngine;
using System.Collections;
using System;

public class Gameplay : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel ("GameTemplate");
		}
	}
}
