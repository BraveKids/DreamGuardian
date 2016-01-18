using UnityEngine;
using System.Collections;

public class ShowSplashes : MonoBehaviour {
	float splash_pause = 1f;
	public GameObject first_splash;			// first splash to be shown
	public GameObject second_splash;
	// Use this for initialization
	void Start () {
		StartCoroutine (SplashScreen ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator SplashScreen () {
		first_splash.SetActive (true);
		yield return new WaitForSeconds (splash_pause);
		first_splash.SetActive (false);
		second_splash.SetActive (true);
		yield return new WaitForSeconds (splash_pause);
		second_splash.SetActive (false);		
		Application.LoadLevel ("Menu");
		yield return null;
	}
}
