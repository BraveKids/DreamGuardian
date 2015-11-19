using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class Game {
	public static Game current;
	public string state;

	public Game(){
		state = "Ora "+DateTime.Now.Hour+":"+DateTime.Now.Minute+":"+DateTime.Now.Second;
	}

}
