using UnityEngine;
using System.Collections;

public class SetYume : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 savedPos = new Vector3(SaveLoad.Instance.savedGame.x, SaveLoad.Instance.savedGame.y, transform.position.z);
		transform.position = savedPos;
		Debug.Log("Dai stampa"+savedPos);
	}
	

}
