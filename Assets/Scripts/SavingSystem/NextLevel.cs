using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	public GameObject levelStart;
	public int level;

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.CompareTag ("Player")) {
			if (level != null) {
				SaveLoad.setLevel (level);
			}

			GameObject nextLevel = levelStart.transform.FindChild ("reachLevel").gameObject;
			GameObject savePoint = levelStart.transform.FindChild ("SavePoint").gameObject;
			
			SaveLoad.savedGame.x = nextLevel.transform.position.x;
			SaveLoad.savedGame.y = nextLevel.transform.position.y;

			SaveLoad.Spawn ();	
			CameraFollowOnPlatform.instance.onNewLevel (savePoint.transform.position);


		}		
	}
}
