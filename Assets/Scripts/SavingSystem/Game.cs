using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[System.Serializable]
public class Game {
	public static Game current;
	public float x;
	public float y;
	public bool firstGame = true;
	public List<String> skills;
	public int level;

	public Game () {

		level = -1;
		skills = new List<String> ();
		//skills.Add ("arrowAbility");
		skills.Add ("platformAbility");

		
	}

}
