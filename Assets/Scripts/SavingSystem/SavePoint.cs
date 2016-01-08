using UnityEngine;
using System.Collections;

public class SavePoint : MonoBehaviour {

	private bool usable = true;
	string id;

	void Start () {
		id = GetComponent<GUIText> ().text;

		//if the saving point is already in the dict
		if (SavingPoints.pointsDict.ContainsKey (id)) {
			usable = SavingPoints.pointsDict [id];
		} else {
			//add the saving point to the dict
			SavingPoints.pointsDict.Add (id, true);
		} 

		setColor ();

	}

	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.CompareTag ("Player") && usable) {

			Debug.Log(other.gameObject.transform.position.x-transform.position.x);

			SavingPoints.pointsDict [id] = false;

			usable = false;
			setColor ();

			SavingPoints.Save ();
			SaveLoad.SaveGame ();
			Debug.Log ("salvando");
			//in case he's coming from a level change and is running
			CameraFollowOnPlatform.instance.setFollowYume(true);
			other.gameObject.GetComponent<CharacterControllerScript>().stopRunYume();	
		}		
	}

	void setColor () {
		SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer> ();

		if (usable) {
			renderer.color = new Color (0f, 1f, 0f, 1f);
		} else {
			renderer.color = new Color (1f, 0f, 0f, 1f);
		}
	}
}
