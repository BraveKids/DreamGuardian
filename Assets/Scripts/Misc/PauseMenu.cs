using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PauseMenu : MonoBehaviour {
	public GameObject player;
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
		//player.GetComponent<CharacterControllerScript> ().stopYume();
		gameObject.SetActive (true);
		SoundManager.instance.SetMusic(false);
	}
	
	public void hidePauseMenu () {
		gameObject.SetActive (false);
		//player.GetComponent<CharacterControllerScript> ().goYume();
		Time.timeScale = 1;		
		SoundManager.instance.SetMusic(true);
	}
	
	public void continueGame () {
		hidePauseMenu ();
	}
	
	public void toMainMenu () {
		SaveLoad.savedGame.level = -1;
		Time.timeScale = 1;
		Camera.main.GetComponent<CameraFollowOnPlatform> ().enabled = false;		
		hidePauseMenu ();
		Application.LoadLevel ("menu");
	}



}
