using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class menuManagerWrapper : MonoBehaviour {

	public List<Button> buttons;
	int selected;
	int count;
	GameObject menuManager;
	float lastAxisY;
	float axisRange = 0.7f;

	// Use this for initialization
	void Start () {	
		menuManager = GameObject.Find ("MenuManager");
		selected = 0;
		count = 0;
		buttons = new List<Button> ();

		foreach (Transform child in transform) {
			if (child.gameObject.GetComponent<Button> ().interactable == true) {
				buttons.Add (child.gameObject.GetComponent<Button> ());
			}
		}
		buttons [0].image.color = Color.red;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Vertical") < axisRange && Input.GetAxis ("Vertical") > -axisRange) {
			lastAxisY = 0;
		}
	
		if (Input.GetKeyDown (KeyCode.DownArrow) || (Input.GetAxis ("Vertical") <= -axisRange && lastAxisY != -1)) {
			lastAxisY = -1;
			count++;
			updateMenu ();
		}
		if (Input.GetKeyDown (KeyCode.UpArrow) || (Input.GetAxis ("Vertical") >= axisRange && lastAxisY != 1)) {
			count--;
			lastAxisY = 1;
			if (count < 0) {
				count = 3;
			}
			updateMenu ();
		}

		for (int i = 4; i < 20; i++) {
			if (Input.GetKeyDown ("joystick 1 button " + i)) {
				print ("joystick 1 button " + i);
			}
		}


		if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.Joystick1Button0)) {
			buttons [selected].onClick.Invoke ();
		}

		if (Input.GetKeyDown (KeyCode.Backspace) || Input.GetKeyDown (KeyCode.Joystick1Button1)) {
			menuManager.GetComponent<MenuManager> ().GoToMenu ();
		}
	}

	void updateMenu () {

		selected = count % 4;
		Debug.Log ("selected: " + selected + " count: " + count);
		for (int i=0; i < buttons.Count; i++) {

			if (i == selected) {
				buttons [i].image.color = Color.red;
			} else {
				buttons [i].image.color = Color.grey;
			}
		}
	}
}
