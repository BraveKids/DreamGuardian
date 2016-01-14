using UnityEngine;
using System.Collections;

public class LifeRefill : MonoBehaviour {
	GameObject player;
	private CharacterControllerScript playerScript;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerScript = player.gameObject.GetComponent("CharacterControllerScript") as CharacterControllerScript;
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			playerScript.hp = 4;
			GameObject.Find ("HUD").GetComponent<HUDManager> ().updateHP (playerScript.hp);
			gameObject.SetActive(false);
		}
	}
}
