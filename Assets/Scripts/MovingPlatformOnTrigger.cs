using UnityEngine;
using System.Collections;

public class MovingPlatformOnTrigger : MonoBehaviour {
	public GameObject platform;
	public float moveSpeed;
	public Transform EndPoint;
	public Transform StartPoint;


	void OnTriggerStay2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			MovePlatform ();
		}
	}
	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			Invoke("MovePlatformBack", 4f);
		}
		
		
	}
	void MovePlatform(){
		platform.transform.position = Vector3.MoveTowards (platform.transform.position, EndPoint.position,moveSpeed);
	}
	
	void MovePlatformBack(){
		platform.transform.position = StartPoint.position;
	}


}


		

	

