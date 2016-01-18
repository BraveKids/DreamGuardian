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
	public AudioClip chase;
	public AudioClip menuMusic;
	public AudioClip forest;
	public AudioClip lvl0Music;
	public AudioClip schoolMusic;	//high school music? LOL


	
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
		allMusics.Add ("chase", chase);
		allMusics.Add ("menu", menuMusic);
		allMusics.Add("lvl0", lvl0Music);
		allMusics.Add("school", schoolMusic);
		allMusics.Add ("forest", forest);
	
		
		audioSource = GetComponent<AudioSource> () as AudioSource;
		audioSource.loop = true;
		SetBackgroundMusic ("menu");
		//audioSource.Play ();
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
