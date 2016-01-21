using UnityEngine;
using System.Collections;

public class CordaScript : MonoBehaviour {
	public GameObject GorillaBoss;
	private GorillaBossScript gorillaScript;
	// Use this for initialization
	void Start () {
		gorillaScript = GorillaBoss.gameObject.GetComponent("GorillaBossScript") as GorillaBossScript;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
			if (other.CompareTag ("AttackTrigger")) {
				if (gorillaScript.onRope == true) {
				this.gameObject.SetActive (false);
			}
		}
}
}
