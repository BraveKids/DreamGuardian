using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class menuManager : MonoBehaviour {

	List<GameObject> buttons;
	int selected;


	// Use this for initialization
	void Start () {	
		selected = 0;
		buttons = new List<GameObject> ();

		foreach (Transform child in transform) {
			buttons.Add (child.gameObject);
			Debug.Log (child.ToString ());
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			selected++;
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			selected--;
		}
		selected = selected % 4;
		if (Input.GetKeyDown (KeyCode.Return)) {
			buttons [selected].GetComponent<Button> ().onClick.Invoke ();
		}
	}
}
