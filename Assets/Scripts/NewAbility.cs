using UnityEngine;
using System.Collections;

public class NewAbility : MonoBehaviour {

	public string ability;

	void OnTriggerEnter2D (Collider2D other) {


		if (other.CompareTag ("Player")) {
			if (!SaveLoad.savedGame.skills.Contains(ability)) {	//se non ho quell'abilità
				
				SaveLoad.savedGame.skills.Add (ability);	//ottenimento dell'abilità

				transform.GetChild (0).GetComponent<dialogManager> ().Activate ();	//attivo il dialogo

				SaveLoad.SaveGame();
			}
		
			
		}
	}
}
