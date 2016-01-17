using UnityEngine;
using System.Collections;

public class changeSong : MonoBehaviour {
	public string song;

	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.CompareTag ("Player") && song!=null) {
			SoundManager.instance.SetBackgroundMusic (song);
		}
	}
}
