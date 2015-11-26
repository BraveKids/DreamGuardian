using UnityEngine;
using System.Collections;

public class SavePoint : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.CompareTag ("Player")) {
			SaveLoad.Instance.SaveGame();
			Debug.Log("salvando");
		}

		
	}
}
