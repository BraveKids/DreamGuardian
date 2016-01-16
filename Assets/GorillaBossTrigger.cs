using UnityEngine;
using System.Collections;

public class GorillaBossTrigger : MonoBehaviour {
	public GameObject GorillaBoss;
	private GorillaBossScript gorillaScript;
	// Use this for initialization
	void Start () {
		gorillaScript = GorillaBoss.gameObject.GetComponent("GorillaBossScript") as GorillaBossScript;
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			gorillaScript.active = true;
			gorillaScript.anim.SetBool("attack", true);
			this.gameObject.SetActive(false);
		}
	}
}
