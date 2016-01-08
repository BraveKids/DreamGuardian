using UnityEngine;
using System.Collections;

public class KnightTriggerScript : MonoBehaviour {
	public GameObject KnightBoss;
	private KnightBossScript KnightBossScript;

	void Start(){
		KnightBossScript = KnightBoss.gameObject.GetComponent ("KnightBossScript") as KnightBossScript;
	}

	void OnTriggerExit2D(Collider2D other){
	if (other.CompareTag ("Player") && KnightBossScript.tooLate==true) {
			KnightBossScript.crashOnWall = true;

		}
	}



}
