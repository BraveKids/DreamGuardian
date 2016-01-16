using UnityEngine;
using System.Collections;

public class initialScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		SoundManager.instance.SetBackgroundMusic ("game");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
