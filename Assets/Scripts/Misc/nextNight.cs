using UnityEngine;
using System.Collections;

public class nextNight : MonoBehaviour {

	public GameObject nightStart;
	public int level;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			other.gameObject.GetComponent<CharacterControllerScript> ().stopYume();
			CameraFollowOnPlatform.instance.setFollowYume (false);

			//Animazione con sabbia
			//System.Threading.Thread.Sleep (2000);
			//"teletrasporto" di yume

			if (level != null) {
				SaveLoad.setLevel (level);
			}
				
			SaveLoad.savedGame.x = nightStart.transform.position.x;
			SaveLoad.savedGame.y = nightStart.transform.position.y;
				
			SaveLoad.Spawn ();	
			//fai partire animazione per la ricomposizione

			CameraFollowOnPlatform.instance.onNewLevel (nightStart.transform.position);
			other.gameObject.GetComponent<CharacterControllerScript> ().goYume();
			
				
				
		}		
	}	
}

