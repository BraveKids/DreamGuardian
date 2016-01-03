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
	private float originY;
	private float AWAY = 2000;
	

	// Use this for initialization
	void Start () {
		//getting component
		textBox = GameObject.Find ("dialogPanel");
		theText = textBox.transform.GetComponentInChildren<Text> ();
		originY = textBox.transform.position.y;	//need for reset the dialog later
		//textBox.SetActive(false);
		//Sia chiaro che sto modo di nascondere la roba lo odio. Ma a quanto pare usare SetActive rende l'ogetto irragiungibile da altri
		textBox.transform.position = new Vector3 (textBox.transform.position.x, AWAY, textBox.transform.position.z);

		if (textFile != null) {
			textLines = textFile.text.Split ('\n');
		}


		endAtLine = textLines.Length - 1;
	
		gameObject.SetActive (false);
	}

	public void Activate () {
		//PER TOMMASO
		//Bloccare i movimenti di yume qui richiamando un metodo che scrivi in characterControllerScript

		active = true;
		gameObject.SetActive (true);


		//textBox.SetActive (true);
		textBox.transform.position = new Vector3 (textBox.transform.position.x, originY, textBox.transform.position.z);
		
		theText.text.Remove (0);
	}

	public void Deactivate () {
		active = false;

		//textBox.SetActive (false);
		textBox.transform.position = new Vector3 (textBox.transform.position.x, AWAY, textBox.transform.position.z);
		gameObject.SetActive(false);
		
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
}

