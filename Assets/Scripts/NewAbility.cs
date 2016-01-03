using UnityEngine;
using System.Collections;

public class NewAbility : MonoBehaviour {

	public string ability;
	private bool notMet = true;

	void OnTriggerEnter2D (Collider2D other) {


		if (other.CompareTag ("Player")) {
			if (notMet) {
				notMet = false;
				
				SaveLoad.savedGame.skills.Add (ability);

				transform.GetChild (0).GetComponent<dialogManager> ().Activate ();

				
			}
		
			
		}
	}
}
