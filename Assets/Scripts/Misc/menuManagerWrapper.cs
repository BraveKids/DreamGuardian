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
	int numButton = 0;
	float t;
	float transitionDuration = 1f;
	float scaleX;
	float scaleY;
	float scaleZ;
	

	// Use this for initialization
	void Start () {	


		
		menuManager = GameObject.Find ("MenuManager");
		t = 0f;
		selected = 0;
		count = 0;
		buttons = new List<Button> ();

		foreach (Transform child in transform) {
			if (child.gameObject.GetComponent<Button> ().interactable == true) {
				buttons.Add (child.gameObject.GetComponent<Button> ());
				numButton++;
			}
		}	

		scaleX = buttons [0].transform.localScale.x;
		scaleY = buttons [0].transform.localScale.y;
		scaleZ = buttons [0].transform.localScale.z;

		Debug.Log ("Valori di scala: " + scaleX + " " + scaleY + " " + scaleZ);
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

		if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.Joystick1Button0)) {
			buttons [selected].onClick.Invoke ();
		}

		if (Input.GetKeyDown (KeyCode.Backspace) || Input.GetKeyDown (KeyCode.Joystick1Button1)) {
			menuManager.GetComponent<MenuManager> ().GoToMenu ();
		}

		if (t < 1f) {
			t += Time.deltaTime / transitionDuration;
			float delta = nextGaussian (t) * 0.15f;
	
			buttons [selected].transform.localScale = new Vector3 (scaleX + delta, (scaleY + delta), scaleZ);
			if (t > 1f) {
				t = 0f;
			}
		}


	}

	void updateMenu () {
		buttons [selected].transform.localScale = new Vector3 (scaleX, scaleY, scaleZ);
		selected = count % numButton;

	
	}

	float nextGaussian (float x) {
		double sigma = 0.4;
		double mu = 0.5;
		double n1 = 1 / Math.Sqrt (2 * Math.PI * Math.Pow (sigma, 2));

		double n2_1 = (x - mu) / sigma;
		double n2_2 = Math.Exp (-0.5 * Math.Pow (n2_1, 2));

		return (float)(n1 * n2_2);
	}


}
