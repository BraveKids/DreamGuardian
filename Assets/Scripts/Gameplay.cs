using UnityEngine;
using System.Collections;
using System;

public class Gameplay : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//FirstGame();

		SaveLoad.Load();

		Debug.Log (SaveLoad.savedGame.state);
		SaveLoad.savedGame.state="Ora "+DateTime.Now.Hour+":"+DateTime.Now.Minute+":"+DateTime.Now.Second;
		SaveLoad.Save();
		SaveLoad.Load();
		Debug.Log(SaveLoad.savedGame.state);


	}

	void FirstGame(){
		SaveLoad.savedGame.state="Ora "+DateTime.Now.Hour+":"+DateTime.Now.Minute+":"+DateTime.Now.Second;
		SaveLoad.Save();
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel ("GameTemplate");
		}
	}
}
