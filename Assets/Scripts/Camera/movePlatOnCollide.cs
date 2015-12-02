using UnityEngine;
using System.Collections;

public class movePlatOnCollide : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {

			MovingPlatfrom.CAN_MOVE = true;
				
	}

}
