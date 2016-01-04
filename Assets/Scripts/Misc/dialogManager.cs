using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class dialogManager : MonoBehaviour {
	private GameObject textBox;
	private Text theText;
	public TextAsset textFile;
	public string[] textLines;
	private int currentLine = 0;
	private int endAtLine;
	private bool active = false;
	

	// Use this for initialization
	void Start () {
		//getting component
		textBox = GameObject.Find ("dialogPanel");
		theText = textBox.transform.GetComponentInChildren<Text> ();


		showDialog (false);	//hide the dialog box

		if (textFile != null) {
			textLines = textFile.text.Split ('\n');
		}


		endAtLine = textLines.Length - 1;
	
		gameObject.SetActive (false);	//stop the script
	}

	public void Activate () {
		//PER TOMMASO
		//Bloccare i movimenti di yume qui richiamando un metodo che scrivi in characterControllerScript

		active = true;
		gameObject.SetActive (true);	//riattivo lo script e il conseguente metodo update

		showDialog (true);	//show dialog box		
	}

	public void Deactivate () {
		active = false;


		showDialog (false);

		gameObject.SetActive (false);
		
	}

	void Update () {
		if (active) {
			theText.text = textLines [currentLine];

			if (Input.GetKeyDown (KeyCode.Return)) {
				currentLine++;
			}

			if (currentLine > endAtLine) {
				Deactivate ();
				//PER TOMMASO
				//come sopra ma riattivare yume
			}
		}
	}

	void showDialog (bool show) {
		textBox.GetComponent<Image> ().enabled = show;	//enabled/disabled the dialogBox
		theText.text = "";	//clean the text
		
	}
}

