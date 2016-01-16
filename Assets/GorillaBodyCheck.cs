using UnityEngine;
using System.Collections;

public class GorillaBodyCheck : MonoBehaviour {
	public GameObject GorillaBoss;
	private GorillaBossScript gorillaScript;
	// Use this for initialization
	void Start () {
		gorillaScript = GorillaBoss.gameObject.GetComponent("GorillaBossScript") as GorillaBossScript;
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Ground")){
		   gorillaScript.grounded = true;
	}
}

	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag ("Ground")) {
			gorillaScript.grounded = false;
		}
	}
}