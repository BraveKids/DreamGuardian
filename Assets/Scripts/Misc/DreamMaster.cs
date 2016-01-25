using UnityEngine;
using System.Collections;

public class DreamMaster : MonoBehaviour {

	public string ability;
	Animator anim;
	AudioSource audio;
	bool used;
	void Start () {
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D (Collider2D other) {


		if (other.CompareTag ("Player") && !used) {
			audio.PlayOneShot (audio.clip);
			if (ability != null) {
				if (!SaveLoad.savedGame.skills.Contains (ability)) {	//se non ho quell'abilità
					anim.Play ("GiveAbility");	
					SaveLoad.savedGame.skills.Add (ability);	//ottenimento dell'abilità
					GameObject.FindGameObjectWithTag ("Player").GetComponent<CharacterControllerScript> ().setAbility (ability);
					GameObject.FindGameObjectWithTag ("Player").GetComponent<CharacterControllerScript> ().energy = 10;
					GameObject.Find ("HUD").GetComponent<HUDManager> ().updateMP (GameObject.FindGameObjectWithTag ("Player").GetComponent<CharacterControllerScript> ().energy);
				
				}
			}	
			transform.GetChild (0).GetComponent<dialogManager> ().Activate ();	//attivo il dialogo
				
			SaveLoad.SaveGame ();
			used = true;
			
		}
	}
}
