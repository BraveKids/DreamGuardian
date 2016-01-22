using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {

	public static SoundManager instance = null;
	Dictionary<string,AudioClip> allMusics;

	// source
	AudioSource audioSource = null;

	// clips 
	public AudioClip lullaby;
	public AudioClip tutorial;
	public AudioClip school;
	string musicPlayed;


	
	// Use this for initialization
	void Start () {

		// singleton
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}

		allMusics = new Dictionary<string, AudioClip> ();
		allMusics.Add ("lullaby", lullaby);
		allMusics.Add ("tutorial", tutorial);
		allMusics.Add ("school", school);
	
		
		audioSource = GetComponent<AudioSource> () as AudioSource;
		audioSource.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
		switch (SaveLoad.savedGame.level) {
		case 0:
			SetBackgroundMusic ("lullaby");
			break;
		case 1:
			SetBackgroundMusic ("tutorial");
			break;
		case 2:
			SetBackgroundMusic ("school");
			break;
		}
	}

	public void SetVolume (float _volume) {
		audioSource.volume = _volume;
	}

	public void SetBackgroundMusic (string background) {
		if (allMusics.ContainsKey (background) && musicPlayed!=background) {
			audioSource.clip = allMusics [background];
			musicPlayed = background;
			Debug.Log("musica cambiata con livello: "+SaveLoad.savedGame.level);
		}


		audioSource.Play ();
	}

	public void SetMusic (bool _music) {
		if (audioSource.isPlaying == true && _music == false) {
			audioSource.Stop ();
		}
		if (audioSource.isPlaying == false && _music == true) {
			audioSource.Play ();
		}
	}
}
