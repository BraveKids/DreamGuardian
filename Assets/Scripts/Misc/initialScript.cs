using UnityEngine;
using System.Collections;

public class initialScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (!Application.isEditor) {
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
		SoundManager.instance.SetBackgroundMusic ("game");
	}
	

}
