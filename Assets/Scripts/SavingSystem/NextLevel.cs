using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	public GameObject nextLevel;
	public GameObject savePoint;
	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.CompareTag ("Player")) {
			SaveLoad.savedGame.x = nextLevel.transform.position.x;
			SaveLoad.savedGame.y = nextLevel.transform.position.y;
			Debug.Log(nextLevel.transform.position.x-transform.position.x);
			//SaveLoad.SaveGame();
			CameraFollowOnPlatform.instance.setFollowYume(false,savePoint.transform.position);
			SaveLoad.Spawn();			
		}		
	}
}
