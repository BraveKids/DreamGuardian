using UnityEngine;
using System.Collections;

public class MovingPlatformOnTrigger : MonoBehaviour {
	public GameObject platform;
	public float moveSpeed;
	public Transform EndPoint;


	void OnTriggerStay2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			MovePlatform();
		}
		
		
	}
	void MovePlatform(){
		platform.transform.position = Vector3.MoveTowards (platform.transform.position, EndPoint.position,moveSpeed);
	}

	
}


		

	

