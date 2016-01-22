using UnityEngine;
using System.Collections;

public class DreamMaster : MonoBehaviour {

	public string ability;
	Animator anim;
	AudioSource audio;
	void Start(){
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
	}

	public void byeBye(){
		//SALUTA
		Debug.Log("ciaooo");
	}

	void OnTriggerEnter2D (Collider2D other) {


		if (other.CompareTag ("Player")) {
			audio.PlayOneShot(audio.clip);
			if (!SaveLoad.savedGame.skills.Contains(ability)) {	//se non ho quell'abilità
				anim.Play("GiveAbility");	
				SaveLoad.savedGame.skills.Add (ability);	//ottenimento dell'abilità

				transform.GetChild (0).GetComponent<dialogManager> ().Activate ();	//attivo il dialogo

				SaveLoad.SaveGame();

				GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControllerScript>().setAbility(ability);
				GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControllerScript>().energy = 10;
				GameObject.Find ("HUD").GetComponent<HUDManager> ().updateMP (GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControllerScript>().energy);
			}	
			
		}
	}
}
