using UnityEngine;
using System.Collections;

public class GorillaBodyCheck : MonoBehaviour {
	public GameObject GorillaBoss;
	public AudioSource fallSound;
	private GorillaBossScript gorillaScript;
	// Use this for initialization
	void Start () {
		gorillaScript = GorillaBoss.gameObject.GetComponent("GorillaBossScript") as GorillaBossScript;
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Ground")){
		   fallSound.PlayOneShot(fallSound.clip);
		   gorillaScript.grounded = true;
			Invoke ("DisableSound", 0.5f);

	}
}

	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag ("Ground")) {
			gorillaScript.grounded = false;
			fallSound.enabled = true;
		}
	}

	void DisableSound(){
		fallSound.enabled = false;
	}
}