using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad {

	public string SAVING_PATH = Application.persistentDataPath + "/savedGames.gd";
	public Game savedGame = new Game ();
	public GameObject player = GameObject.FindGameObjectWithTag ("Player");


	//singleton
	private static SaveLoad instance;
	
	private SaveLoad () {
	}
	
	public static SaveLoad Instance {
		get {
			if (instance == null) {
				instance = new SaveLoad ();
			}
			return instance;
		}
	}






	//it's static so we can call it from anywhere
	public  void Save () {
		BinaryFormatter bf = new BinaryFormatter ();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create (SAVING_PATH); //you can call it anything you want
		bf.Serialize (file, savedGame);
		file.Close ();
	}
	
	public void Load () {
		if (File.Exists (SAVING_PATH)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (SAVING_PATH, FileMode.Open);
			savedGame = (Game)bf.Deserialize (file);
			file.Close ();
		}
	}

	public void ContinueGame () {
		Load ();
		Debug.Log ("Continued");
	}

	public void SaveGame () {
		instance.savedGame.x = instance.player.transform.position.x;
		instance.savedGame.y = instance.player.transform.position.y;
		Save ();
		Debug.Log ("Game saved");
		
	}
	
	public void FirstGame () {
		Debug.Log ("New Game");
		savedGame.x = -22.30036f;
		savedGame.y = -2.331829f;
	}

}
