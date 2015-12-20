using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	public GameObject nextLevel;
	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.CompareTag ("Player")) {
			SaveLoad.savedGame.x = nextLevel.transform.position.x;
			SaveLoad.savedGame.y = nextLevel.transform.position.y;
			//SaveLoad.SaveGame();
			SaveLoad.Spawn();			
		}		
	}
}
