using UnityEngine;
using System.Collections;

public class KnightBossAttackTrigger : MonoBehaviour {
	public GameObject KnightBoss;
	private KnightBossScript knightScript;
	// Use this for initialization
	void Start () {
		knightScript = KnightBoss.gameObject.GetComponent("KnightBossScript") as KnightBossScript;
		
	}


	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			if (knightScript.stun == false) {
				knightScript.anim.Play ("attack");
				knightScript.moveBackToStart ();
			}
		}
	}
}
