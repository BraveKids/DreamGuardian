using UnityEngine;
using System.Collections;

public class nextNight : MonoBehaviour {

	public GameObject nightStart;
	public int level;
	GameObject player;
	public bool end;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			player = other.gameObject;
			other.gameObject.GetComponent<CharacterControllerScript> ().stopYume();
			other.gameObject.GetComponent<Animator>().Play("flare");
			CameraFollowOnPlatform.instance.setFollowYume (false);
			Invoke ("Teleport", 2.1f);

			if(end){
				Application.LoadLevel("Ending");
			}
				
		}		
	}

	void Teleport(){
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
		player.gameObject.GetComponent<Animator> ().Play ("respawn");
		player.gameObject.GetComponent<CharacterControllerScript> ().goYume();

	}

	
}

