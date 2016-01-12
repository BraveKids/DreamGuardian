using UnityEngine;
using System.Collections;

public class DreamMaster : MonoBehaviour {

	public string ability;
	Animator anim;

	void Start(){
		anim = GetComponent<Animator> ();
	}

	public void byeBye(){
		//SALUTA
		Debug.Log("ciaooo");
	}

	void OnTriggerEnter2D (Collider2D other) {


		if (other.CompareTag ("Player")) {
			if (!SaveLoad.savedGame.skills.Contains(ability)) {	//se non ho quell'abilità
				anim.Play("GiveAbility");	
				SaveLoad.savedGame.skills.Add (ability);	//ottenimento dell'abilità

				transform.GetChild (0).GetComponent<dialogManager> ().Activate ();	//attivo il dialogo

				SaveLoad.SaveGame();

				GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControllerScript>().setAbility(ability);
			}	
			
		}
	}
}
