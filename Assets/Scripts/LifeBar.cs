using UnityEngine;
using System.Collections;

public class LifeBar : MonoBehaviour {
	public GameObject heart1;
	public GameObject heart2;
	public GameObject heart3;
	public GameObject energy1;
	public GameObject energy2;
	public GameObject energy3;
	private CharacterControllerScript playerLifeScript;
	private PlayerAttack playerEnergyScript;
	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

		playerLifeScript = player.gameObject.GetComponent ("CharacterControllerScript") as CharacterControllerScript;
		playerEnergyScript = player.gameObject.GetComponent ("PlayerAttack") as PlayerAttack;
	}
	
	// Update is called once per frame
	void Update () {

		checkLifeBar ();
		//checkEnergyBar ();
		
	}

	void checkLifeBar () {
		if (playerLifeScript.hp < 3) {
			heart3.gameObject.SetActive (false);
		}
		if (playerLifeScript.hp < 2) {
			heart2.gameObject.SetActive (false);
		}
		if (playerLifeScript.hp < 1) {
			heart1.gameObject.SetActive (false);
		}

	}

	void checkEnergyBar () {
		if (playerEnergyScript.energy == 1) {
			energy1.gameObject.SetActive (true);
		}
		if (playerEnergyScript.energy == 2) {
			energy2.gameObject.SetActive (true);
		}
		if (playerEnergyScript.energy == 3) {
			energy3.gameObject.SetActive (true);
		}
		if (playerEnergyScript.energy == -1) {
			playerEnergyScript.energy = 0;
			resetEnergyBar ();
		}
	}

	void resetEnergyBar () {
		energy1.gameObject.SetActive (false);
		energy2.gameObject.SetActive (false);
		energy3.gameObject.SetActive (false);
	}

	void resetLifeBar () {
		heart1.gameObject.SetActive (true);
		heart2.gameObject.SetActive (true);
		heart3.gameObject.SetActive (true);
	}
}
