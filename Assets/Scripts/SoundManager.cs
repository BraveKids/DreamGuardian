using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {

	public static SoundManager instance = null;

	// source
	AudioSource audioSource = null;

	// clips 
	public AudioClip menu_background; 
	public AudioClip game_background;
	
	// Use this for initialization
	void Start () {

		// singleton
		if (instance==null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}

		audioSource = GetComponent<AudioSource>() as AudioSource;
		audioSource.loop = true;
		audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetVolume(float _volume)
	{
		audioSource.volume = _volume;
	}

	public void SetBackgroundMusic(int _background) {
		if (_background==0)
		{
			audioSource.clip = menu_background;
		} else {
			audioSource.clip = game_background;
		}

		audioSource.Play ();
	}

	public void SetMusic(bool _music) {
		if (audioSource.isPlaying == true && _music == false)
			audioSource.Stop();
		if (audioSource.isPlaying == false && _music == true)
			audioSource.Play();
	}
}
