using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Joystick1Button7)) {
			hidePauseMenu ();
		}
	}
	
	void showPauseMenu () {
		gameObject.SetActive (true);
		Time.timeScale = 0;
	}
	
	void hidePauseMenu () {
		gameObject.SetActive (false);
	}
	
	public void continueGame () {
		hidePauseMenu ();
		Time.timeScale = 1;
	}
	
	public void toMainMenu () {
		Application.LoadLevel ("menu");
	}

}
