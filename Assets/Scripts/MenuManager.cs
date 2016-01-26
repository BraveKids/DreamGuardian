using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class MenuManager : MonoBehaviour {

	// menu screens
	public GameObject full_background;		// a unique background for all the menus
	public GameObject menu;
	public GameObject credits;
	public GameObject saving;
	public static bool first_run = true;

	// Use this for initialization
	void Start () {

		//SoundManager.instance.SetBackgroundMusic ("menu");
		GoToMenu ();

	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Backspace) || Input.GetKeyDown (KeyCode.Joystick1Button1)) {
			GoToMenu ();
		}
	}
	
	public void SliderValueChanged (float value) {
		SoundManager.instance.SetVolume (value);
	}

	public void MusicCheckBoxChanged (bool value) {
		SoundManager.instance.SetMusic (value);
	}

	public void GoToMenu () {
		menu.SetActive (true);
		credits.SetActive (false);
		saving.SetActive (false);
	}

	public void GoToSavingMenu () {
		menu.SetActive (false);
		credits.SetActive (false);
		saving.SetActive (true);

		Button continueButton = GameObject.Find ("Continue").GetComponents<Button> () [0]; //restituisce una list di Button, avendone uno solo con [0] sono sicuro di prenderlo

		//check if there is a saved point and disable/able the continue button 
		if (File.Exists (SaveLoad.SAVING_PATH)) {
			continueButton.interactable = true;
		} else {
			continueButton.interactable = false;
		}

	}

	//activate both on Continue and New Game button
	public void GoToGameplay (bool newGame) {
		SoundManager.instance.SetMusic (false);
		//GoToGameplay->Gameplay.cs->SaveLoad.cs->SetYume.cs

		//Gameplay.newGame = newGame; //if true began a new game

		if (newGame) {
			SaveLoad.FirstGame ();
		} else {
			SaveLoad.ContinueGame ();
		}

		// background music

		//SoundManager.instance.SetBackgroundMusic ("game");
		Application.LoadLevel ("Gameplay");

	}

	public void GoToCredits () {
		menu.SetActive (false);
		credits.SetActive (true);
	}

	public void CleanMenus () {
		menu.SetActive (false);
		credits.SetActive (false);
		full_background.SetActive (false);
	}

	public void ExitGame () {
		Application.Quit ();
	}


}
