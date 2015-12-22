using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResetSystem : MonoBehaviour {


	class genObject {
		GameObject gameObj;
		float originX;
		float originY;
		float originZ;
		

		public genObject (GameObject gameObj, float originX, float originY, float originZ) {
			this.gameObj = gameObj;
			this.originX = originX;
			this.originY = originY;
			this.originZ = originZ;
			
		}

		public void resetGameObject(){
			gameObj.SetActive(false);			
			gameObj.SetActive(true);
			gameObj.transform.position = new Vector3(originX,originY,originZ);
			
			
		}


	}

	static List<genObject> objectToRestart = new List<genObject> ();

	void OnLevelWasLoaded (int level) {
		if (level == 1) {
			foreach (GameObject obj in GameObject.FindGameObjectsWithTag("ObjectToReset")) {
				objectToRestart.Add (new genObject (obj, obj.transform.position.x, obj.transform.position.y, obj.transform.position.z));
			}

			foreach (GameObject obj in GameObject.FindGameObjectsWithTag("EnemyObject")) {
				objectToRestart.Add (new genObject (obj, obj.transform.position.x, obj.transform.position.y, obj.transform.position.z));
			}
			Debug.Log("Count: "+objectToRestart.Count);
		}
		
	}

	public static void resetAll () {
		foreach(genObject obj in objectToRestart){
			obj.resetGameObject();
		}
	}
}
