using UnityEngine;
using System.Collections;

public class NewAbility : MonoBehaviour {

	public string ability;
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag("Player"))
			SaveLoad.savedGame.skills.Add(ability);

		//implementare parte che blocca yume durante la spiegazione dell'abilità
	}
}
