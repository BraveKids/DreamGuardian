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
	public AudioClip menu_background;
	public AudioClip game_background;
	
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
		allMusics.Add ("menu", menu_background);
		allMusics.Add ("game", game_background);
		
		audioSource = GetComponent<AudioSource> () as AudioSource;
		audioSource.loop = true;
		audioSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetVolume (float _volume) {
		audioSource.volume = _volume;
	}

	public void SetBackgroundMusic (string background) {

		if (allMusics.ContainsKey (background)) {
			audioSource.clip = allMusics [background];
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
