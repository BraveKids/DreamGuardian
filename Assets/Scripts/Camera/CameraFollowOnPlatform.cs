using UnityEngine;
using System.Collections;
using System.Linq;

public class CameraFollowOnPlatform : MonoBehaviour {

	public static CameraFollowOnPlatform instance = null;
	Vector3 currentOrigin;	//posizione corrente della camera (transform.position), utilizzata per chiarezza del codice

	//public float currentY;
	public float originY;	//basically the ground y
	public bool nextToGround = true;
	GameObject player;
	public float cameraOffset = 1.5f;	//when on ground how much the camera will be lift up from it?

	public float deviationFix = 2f; //if i jump on the spot i get different y position. Fixed it introducing a little range between odl and new position

	public bool isFalling = false;
	private Vector2 velocity;
	public float smoothTimeX;
	public float smoothTimeY;
	public bool on_moving_plat = false;

	//when on moving platform some time is needed to move vertically the camera, and then 
	//the camera will follow the platform. This generate some space lap.
	public float diff_when_moving = 0;

	void Start () {
		// singleton
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
		player = GameObject.FindGameObjectWithTag ("Player");
		currentOrigin = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z);
	}

	void Update () {

		Debug.DrawLine (new Vector3 (player.transform.position.x, transform.position.y + deviationFix, player.transform.position.z), new Vector3 (player.transform.position.x, transform.position.y - deviationFix, player.transform.position.z), Color.green, 2, false);
		

		if (player.transform.position.y < originY + cameraOffset) {
			nextToGround = true;
		} else {
			nextToGround = false;
		}
		//float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);

		float posX = player.transform.position.x;
		//float posY = transform.position.y;

		//if I land on a platform
		/*if (currentY != nextY) {
			StartCoroutine (ResetCamera (nextY));
			currentY = nextY;
			Debug.Log ("moving camera");
		}*/

		float posY = transform.position.y;

		//if on moving platform
		if (on_moving_plat) {
			posY = player.transform.position.y + diff_when_moving;
		}

		//if falling
		if ((player.transform.position.y < transform.position.y) && !nextToGround) {
			posY = player.transform.position.y + diff_when_moving;
			//currentY = transform.position.y;
			//isFalling = true;
			Debug.Log ("FALLING");

		} 

	

		transform.position = new Vector3 (posX, posY, transform.position.z);



		//only used for ResetCamera
		currentOrigin = transform.position;
		
	}


	//this method updata
	public IEnumerator  ResetCamera (float nextY, bool moving_plat) {
		//Debug.DrawLine (new Vector3 (player.transform.position.x + 1f, currentY, player.transform.position.z), new Vector3 (player.transform.position.x - 1f, currentY, player.transform.position.z), Color.red, 2, false);
		
		//if nextY is greater than the origin plus offset due to moving platform, don't move the camera
		float originAndOffset = cameraOffset + originY;
		if (!Range (nextY, transform.position.y - deviationFix, transform.position.y + deviationFix) && !nextToGround) {
			Debug.Log ("Reset camera!");
			//nextY
		
			float transitionDuration = 0.5f;
			//some code
			float t = 0.0f;
			while (t < 1.0f) {
				t += Time.deltaTime * (Time.timeScale / transitionDuration);
				//Vector3 nextPos = new Vector3 (transform.position.x, nextY, transform.position.z);
				Vector3 nextPos = new Vector3 (transform.position.x, nextY, transform.position.z);

				transform.position = Vector3.Lerp (transform.position, nextPos, t);		
				yield return 0;
			}
		}

		//if i get here it means that i'm on a platform, so i'm not falling anymore
		//when the position is updated closely follow the player
		if (moving_plat) {
			diff_when_moving = Mathf.Abs (transform.position.y - player.transform.position.y);
			if (transform.position.y < player.transform.position.y) {
				diff_when_moving = -diff_when_moving;
			}
		}


		on_moving_plat = moving_plat;

		//currentY = transform.position.y;

	}

	bool Range (float numberToCheck, float bottom, float top) {
		return numberToCheck >= bottom && numberToCheck <= top;
	}

}
