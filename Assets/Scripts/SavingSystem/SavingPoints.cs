using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SavingPoints {

	public static string SAVING_POINTS_PATH = Application.persistentDataPath + "/savingPoints.gd";

	//this structure contains all the saving points stored with ID (taken from GUI text component) and a bool that
	//means if i used that checkpoint
	public static Dictionary<string,bool> pointsDict = new Dictionary<string,bool>();

	/*private static SavingPoints instance;
	
	private SavingPoints () {
	}
	
	public static SavingPoints Instance {
		get {
			if (instance == null) {
				instance = new SavingPoints ();
			}
			return instance;
		}
	}*/



	public static  void Save () {
		BinaryFormatter bf = new BinaryFormatter ();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create (SAVING_POINTS_PATH); //you can call it anything you want
		bf.Serialize (file, pointsDict);
		file.Close ();
	}
	
	public static void Load () {
		if (File.Exists (SAVING_POINTS_PATH)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (SAVING_POINTS_PATH, FileMode.Open);
			pointsDict = (Dictionary<string,bool>)bf.Deserialize (file);
			file.Close ();
		}
	}
	

}
