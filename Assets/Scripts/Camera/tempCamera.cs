using UnityEngine;
using System.Collections;

public class tempCamera : MonoBehaviour {
	GameObject player;
	float originY;

	void Start () {
		originY = transform.position.y;
		player = GameObject.FindGameObjectWithTag ("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
		float cameraX = player.transform.position.x;
		float cameraY = transform.position.y;
		if(player.transform.position.y > originY + 0.5)
			cameraY = player.transform.position.y - 0.5f;

		transform.position = new Vector3 (cameraX, cameraY, transform.position.z);
	}
}
