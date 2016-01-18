using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	public void Start () {
		showPauseMenu ();
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
		Time.timeScale = 1;		
	}
	
	public void continueGame () {
		hidePauseMenu ();
	}
	
	public void toMainMenu () {
		Camera.main.GetComponent<CameraFollowOnPlatform> ().enabled = false;
		
		hidePauseMenu ();
		Time.timeScale = 1;
		Application.LoadLevel ("menu");
	}

}
