using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Enemy") || other.CompareTag("EnemyBody" )) {
			this.gameObject.SetActive(false);
}
}
}

