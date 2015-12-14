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

	public float deviationFix = 0.2f; //if i jump on the spot i get different y position. Fixed it introducing a little range between odl and new position

	//used for ResetCamera, no need to explain
	private Vector2 velocity;
	public float smoothTimeX;
	public float smoothTimeY;
	float t = 0.0f;
<<<<<<< HEAD
	public bool on_moving_plat = false;
	bool movingCamera = false;
	public float nextY;
=======
	public bool onMovingPlat = false;
	bool movingCamera = false;
	public float nextY;

>>>>>>> camera_follow
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

		float playerY = player.transform.position.y;

		Debug.DrawLine (new Vector3 (player.transform.position.x, transform.position.y + deviationFix, player.transform.position.z), new Vector3 (player.transform.position.x, transform.position.y - deviationFix, player.transform.position.z), Color.green, 2, false);

		float cameraX = player.transform.position.x;
		float cameraY = transform.position.y;
		

		if (playerY < originY + cameraOffset) {
			nextToGround = true;
		} else {
			nextToGround = false;
		}
		//float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);

		//float posY = transform.position.y;


		//if on moving platform
<<<<<<< HEAD
		if (on_moving_plat) {
=======
		if (onMovingPlat) {
>>>>>>> camera_follow
			cameraY = player.transform.position.y + diff_when_moving;
			nextY = cameraY;
		}

		//if falling
		//if i'm out of range and also lower from the bottom then i'm falling
		if (imFalling (playerY, nextY - deviationFix, nextY + deviationFix) && !nextToGround) {
			float diff = cameraY - playerY;
			movingCamera = false;
			cameraY = playerY /*+ diff*/;
		}
	

		transform.position = new Vector3 (cameraX, cameraY, transform.position.z);



		//only used for ResetCamera
		currentOrigin = transform.position;
		
	}

<<<<<<< HEAD
	public void followMe (float nextY, bool moving_plat) {
=======
	public void followMe (float nextY, bool movingPlat) {
>>>>>>> camera_follow
		this.nextY = nextY;
		if (movingCamera) {
			t = 0.0f;
		} else {
<<<<<<< HEAD
			StartCoroutine (ResetCamera (moving_plat));
=======
			StartCoroutine (ResetCamera (movingPlat));
>>>>>>> camera_follow
		}
	}

	//this method updata
<<<<<<< HEAD
	public IEnumerator  ResetCamera (bool moving_plat) {
=======
	public IEnumerator  ResetCamera (bool movingPlat = false) {
>>>>>>> camera_follow
		//Debug.DrawLine (new Vector3 (player.transform.position.x + 1f, currentY, player.transform.position.z), new Vector3 (player.transform.position.x - 1f, currentY, player.transform.position.z), Color.red, 2, false);
		movingCamera = true;
		//if nextY is greater than the origin plus offset due to moving platform, don't move the camera
		bool substantialDiff = outOfRange (nextY, transform.position.y - deviationFix, transform.position.y + deviationFix);
		if (substantialDiff && !nextToGround) {
			Debug.Log ("Reset camera!");
<<<<<<< HEAD
			//nextY
=======
>>>>>>> camera_follow
			t = 0.0f;
			float transitionDuration = 1f;
			//some code
			while (t < 1.0f && movingCamera) {
				t += Time.deltaTime * (Time.timeScale / transitionDuration);
				//Vector3 nextPos = new Vector3 (transform.position.x, nextY, transform.position.z);
				Vector3 nextPos = new Vector3 (transform.position.x, nextY, transform.position.z);

<<<<<<< HEAD
=======
				//don't know why but it seems like it take less than transitionDuration to set the camera so i forced the exit
>>>>>>> camera_follow
				transform.position = Vector3.Lerp (transform.position, nextPos, t);	
				if (nextY == transform.position.y) {
					movingCamera = false;
				}
				yield return 0;
			}
		}
<<<<<<< HEAD
		if (moving_plat) {
=======
		Debug.Log(movingPlat);
		if (movingPlat) {
>>>>>>> camera_follow
			diff_when_moving = Mathf.Abs (transform.position.y - player.transform.position.y);
			if (transform.position.y < player.transform.position.y) {
				diff_when_moving = -diff_when_moving;
			}
			movingPlat = true;
		}
<<<<<<< HEAD
		on_moving_plat = moving_plat;
=======
		onMovingPlat =movingPlat;

>>>>>>> camera_follow
		
		movingCamera = false;

	}

	bool outOfRange (float numberToCheck, float bottom, float top) {
		return numberToCheck < bottom || numberToCheck > top;
	}

	bool imFalling (float playerY, float bottom, float top) {
		return outOfRange (playerY, bottom, top) && playerY < bottom;
	}

}
