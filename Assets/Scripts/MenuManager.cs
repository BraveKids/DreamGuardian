using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour {

	// menu screens
	public GameObject first_splash;			// first splash to be shown
	public GameObject second_splash;		// second splash to be shown
	public GameObject full_background;		// a unique background for all the menus
	public GameObject menu;
	public GameObject leaderboard;
	public GameObject settings;
	public GameObject credits;

	public static bool first_run = true;

	float splash_pause = 1f; 	// every splash stays for one seconds

	// Use this for initialization
	void Start () {
		if (first_run) {
			CleanMenus();
			StartCoroutine(SplashScreen());
			first_run = false;
		} else {
			// menu music
			SoundManager.instance.SetBackgroundMusic(0);
			GoToMenu();
		}
	}
	
	public void SliderValueChanged (float value) {
		SoundManager.instance.SetVolume(value);
	}

	public void MusicCheckBoxChanged (bool value) {
		SoundManager.instance.SetMusic(value);
	}

	public void GoToMenu() {
		menu.SetActive(true);
		leaderboard.SetActive(false);
		settings.SetActive(false);
		credits.SetActive(false);
	}

	public void GoToLeaderboard() {
		menu.SetActive(false);
		leaderboard.SetActive(true);
		settings.SetActive(false);
		credits.SetActive(false);
	}

	public void GoToGameplay() {

		// background music
		SoundManager.instance.SetBackgroundMusic(1);
		Application.LoadLevel("Gameplay");

	}

	public void GoToSettings() {
		menu.SetActive(false);
		leaderboard.SetActive(false);
		settings.SetActive(true);
		credits.SetActive(false);
	}

	public void GoToCredits() {
		menu.SetActive(false);
		leaderboard.SetActive(false);
		settings.SetActive(false);
		credits.SetActive(true);
	}

	public void CleanMenus() {
		menu.SetActive(false);
		leaderboard.SetActive(false);
		settings.SetActive(false);
		credits.SetActive(false);
		full_background.SetActive(false);
	}

	IEnumerator SplashScreen() {
		first_splash.SetActive(true);
		yield return new WaitForSeconds(splash_pause);
		first_splash.SetActive(false);
		second_splash.SetActive(true);
		yield return new WaitForSeconds(splash_pause);
		second_splash.SetActive(false);

		full_background.SetActive(true);

		GoToMenu();
		yield return null;
	}
}
