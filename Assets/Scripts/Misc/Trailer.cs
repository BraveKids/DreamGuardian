using UnityEngine;
using System.Collections;

public class Trailer : MonoBehaviour {

	public AudioSource trailerSong;

	void Start () {
		trailerSong = GameObject.Find ("audio").GetComponent<AudioSource> ();
		((MovieTexture)GetComponent<Renderer> ().material.mainTexture).Play ();
		trailerSong.Play();
	}
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Joystick1Button7)) {
			trailerSong.Stop();
			Application.LoadLevel ("Gameplay");
		}

		if (!trailerSong.isPlaying) {
			Application.LoadLevel ("Gameplay");
		}
			
	}
}
