using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	public GameObject levelStart;

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.CompareTag ("Player")) {
			GameObject nextLevel = levelStart.transform.FindChild ("reachLevel").gameObject;
			GameObject savePoint = levelStart.transform.FindChild ("SavePoint").gameObject;
			
			SaveLoad.savedGame.x = nextLevel.transform.position.x;
			SaveLoad.savedGame.y = nextLevel.transform.position.y;
			Debug.Log (nextLevel.transform.position.x - transform.position.x);
			//SaveLoad.SaveGame();
			SaveLoad.Spawn ();	
			CameraFollowOnPlatform.instance.onNewLevel (savePoint.transform.position);
			Debug.Log ("Yume Y: " + other.transform.position.y);
		}		
	}
}
