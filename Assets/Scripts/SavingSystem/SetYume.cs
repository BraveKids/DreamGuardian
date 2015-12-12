using UnityEngine;
using System.Collections;

public class SetYume : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//when yume is created i can assign it to the script, elsewhere it will raise a nullpointer exception
		SaveLoad.GetYume();
		SaveLoad.Spawn();
	}
	

}
