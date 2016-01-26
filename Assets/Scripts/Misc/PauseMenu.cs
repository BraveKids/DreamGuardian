using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	public void Start () {
		//showPauseMenu ();
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Joystick1Button7)) {
			hidePauseMenu ();
		}
	}
	
	public void showPauseMenu () {
		Time.timeScale = 0;
		
		gameObject.SetActive (true);
	}
	
	public void hidePauseMenu () {
		gameObject.SetActive (false);
		Time.timeScale = 1;		
	}
	
	public void continueGame () {
		hidePauseMenu ();
	}
	
	public void toMainMenu () {
		Time.timeScale = 1;
		Camera.main.GetComponent<CameraFollowOnPlatform> ().enabled = false;		
		hidePauseMenu ();
		Application.LoadLevel ("menu");
	}

}
