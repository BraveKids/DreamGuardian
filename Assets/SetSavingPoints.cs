using UnityEngine;
using System.Collections;

public class SetSavingPoints : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SavingPoints.Load ();
		foreach (Transform child in transform) {
			child.GetComponent<SavePoint> ().enabled = true;
		}
	}

}
