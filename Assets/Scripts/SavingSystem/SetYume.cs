using UnityEngine;
using System.Collections;

public class SetYume : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//when yume is created i can assign it to the script, elsewhere it will raise a nullpointer exception
		SaveLoad.GetYume();
		Vector3 savedPos = new Vector3(SaveLoad.savedGame.x, SaveLoad.savedGame.y, transform.position.z);
		transform.position = savedPos;
		Debug.Log("Dai stampa"+savedPos);
	}
	

}
