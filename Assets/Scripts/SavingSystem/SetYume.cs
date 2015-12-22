using UnityEngine;
using System.Collections;

public class SetYume : MonoBehaviour {
	//public GameObject startPoint; 
	// Use this for initialization
	void Start () {
		//when yume is created i can assign it to the script, elsewhere it will raise a nullpointer exception
		//startPoint = GameObject.FindGameObjectWithTag("StartPoint");
		SaveLoad.GetYume ();
		//SaveLoad.savedGame.x = startPoint.transform.position.x;
		//SaveLoad.savedGame.y = startPoint.transform.position.y;
		SaveLoad.Spawn ();
	}
	

}
