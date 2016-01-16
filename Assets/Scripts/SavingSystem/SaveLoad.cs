using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad {

	public static string SAVING_PATH = Application.persistentDataPath + "/savedGames.gd";
	public static Game savedGame = new Game ();
	public static GameObject player;


	//singleton
	/*private static SaveLoad instance;
	
	private SaveLoad () {
	}
	
	public static SaveLoad Instance {
		get {
			if (instance == null) {
				instance = new SaveLoad ();
			}
			return instance;
		}
	}*/






	//it's static so we can call it from anywhere
	public static  void Save () {
		BinaryFormatter bf = new BinaryFormatter ();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create (SAVING_PATH); //you can call it anything you want
		bf.Serialize (file, savedGame);
		file.Close ();
	}
	
	public static void Load () {
		if (File.Exists (SAVING_PATH)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (SAVING_PATH, FileMode.Open);
			savedGame = (Game)bf.Deserialize (file);
			file.Close ();
		}
	}

	public static void ContinueGame () {
		savedGame.firstGame = false;
		SavingPoints.Load ();
		Load ();
		Debug.Log ("Continued");
	}

	public static void SaveGame () {
		savedGame.x = player.transform.position.x;
		savedGame.y = player.transform.position.y;
		savedGame.firstGame = false;
		Save ();
		Debug.Log ("Game saved");
		
	}
	
	public static  void FirstGame () {
		//cancel previous saved game and saving points
		if (File.Exists (SAVING_PATH)) {
			File.Delete (SAVING_PATH);
		}
		if (File.Exists (SavingPoints.SAVING_POINTS_PATH)) {
			File.Delete (SavingPoints.SAVING_POINTS_PATH);
		}
		Debug.Log ("New Game");
		savedGame.firstGame = true;

	}

	public static void Spawn () {

		if (savedGame.firstGame) {
			GameObject startPoint = GameObject.FindGameObjectWithTag ("StartPoint");
			savedGame.x = startPoint.transform.position.x;
			savedGame.y = startPoint.transform.position.y;
		}
		Vector3 savedPos = new Vector3 (SaveLoad.savedGame.x, SaveLoad.savedGame.y, player.transform.position.z);
		player.transform.position = savedPos;
		savedGame.firstGame = false;
		Camera.main.GetComponent<CameraFollowOnPlatform> ().enabled = true;

		

		//if there are some ability unlocked, take the first
		if (savedGame.skills.Count > 0) {
			player.GetComponent<CharacterControllerScript> ().setAbility (savedGame.skills [0]);
		}

	}

	public static void GetYume () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

}