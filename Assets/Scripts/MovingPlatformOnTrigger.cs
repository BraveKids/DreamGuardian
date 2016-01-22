using UnityEngine;
using System.Collections;

public class MovingPlatformOnTrigger : MonoBehaviour {
	public GameObject platform;
	public float moveSpeed;
	public Transform EndPoint;
	public Transform StartPoint;
	public bool moving;
	public bool movingBack;

	void Start(){
		moving = false;
		movingBack = false;
	}

	void Update(){
		if (moving) {
			platform.transform.position = Vector3.MoveTowards (platform.transform.position, EndPoint.position,moveSpeed);
		}

		if (movingBack) {
			platform.transform.position = Vector3.MoveTowards (platform.transform.position, StartPoint.position,moveSpeed);
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			Invoke("MovePlatform", 1f);
		}
	}
	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			moving = false;
			Invoke("MovePlatformBack", 4f);

		}
		
		
	}
	void MovePlatform(){
		moving = true;
		movingBack = false;
	}
	
	void MovePlatformBack(){
		movingBack = true;
	

		//platform.transform.position = StartPoint.position;
	}


}


		

	

