using UnityEngine;
using System.Collections;

public class EnergyRefill : MonoBehaviour {
	GameObject player;
	private CharacterControllerScript playerScript;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerScript = player.gameObject.GetComponent("CharacterControllerScript") as CharacterControllerScript;
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			playerScript.energy = 10;
			GameObject.Find ("HUD").GetComponent<HUDManager> ().updateMP (playerScript.energy);
			gameObject.SetActive(false);
			Invoke ("Respawn", 5f);
		}
	}

	void Respawn(){
		this.gameObject.SetActive (true);
	}
}
