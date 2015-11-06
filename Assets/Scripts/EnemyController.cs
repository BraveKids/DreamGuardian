using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	Animator anim;
	private float hp = 4;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("AttackTrigger")) {
			hp -= 1;
			anim.SetTrigger ("damage");
			Debug.Log ("OUCH! " + hp + " left!");
			if (hp <= 0) {
				anim.SetTrigger ("explode");
				Invoke ("DestroyEnemy", 0.8f);
			}
		}
	}

	void DestroyEnemy(){
		Destroy (this.gameObject);
	}
}
