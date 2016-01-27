using UnityEngine;
using System.Collections;

public class Ending : MonoBehaviour {

	public AudioSource trailerSong;
	
	void Start () {
		trailerSong = GameObject.Find ("audio").GetComponent<AudioSource> ();
		((MovieTexture)GetComponent<Renderer> ().material.mainTexture).Play ();
		trailerSong.Play();
	}
	// Update is called once per frame
	void Update () {

		
		if (!trailerSong.isPlaying) {
			Application.LoadLevel ("Menu");
		}
		
	}
}
