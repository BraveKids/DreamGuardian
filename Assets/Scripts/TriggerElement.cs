using UnityEngine;
using System.Collections;

public class TriggerElement : MonoBehaviour {
	public GameObject ElementToTrigger;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			ElementToTrigger.gameObject.SetActive(true);
		}
	}
}
