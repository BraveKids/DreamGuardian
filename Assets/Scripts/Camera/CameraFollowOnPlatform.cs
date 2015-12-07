using UnityEngine;
using System.Collections;

public class CameraFollowOnPlatform : MonoBehaviour {

	public static CameraFollowOnPlatform instance = null;
	Vector3 currentOrigin;	//posizione corrente della camera (transform.position), utilizzata per chiarezza del codice

	public float currentY;
	public float originY;	//basically the ground y
	public bool nextToGround = true;
	public bool falling = false;
	GameObject player;
	public float cameraOffset = 1.5f;	//when on ground how much the camera will be lift up from it?

	private Vector2 velocity;
	public float smoothTimeX;
	public float smoothTimeY;
	public bool on_moving_plat = false;

	//when on moving platform some time is needed to move vertically the camera, and then 
	//the camera will follow the platform. This generate some space lap.
	public float diff_when_moving;

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
		if ((player.transform.position.y < currentY) && !nextToGround) {
			falling = true;
			posY = player.transform.position.y;
			currentY = player.transform.position.y;
		} else {
			falling = false;
		}
		//if i'm falling
		/*if (player.transform.position.y + groundDim < currentY) {
			posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y + groundDim, ref velocity.y, smoothTimeY);
			posY = player.transform.position.y + groundDim;
			currentY = player.transform.position.y + groundDim;
			nextY = player.transform.position.y + groundDim;
			
		}*/

		transform.position = new Vector3 (posX, posY, transform.position.z);



		//only used for ResetCamera
		currentOrigin = transform.position;

		//player + ground dim
		Debug.DrawLine (new Vector3 (player.transform.position.x + 0.5f, player.transform.position.y + cameraOffset, player.transform.position.z), new Vector3 (player.transform.position.x - 0.5f, player.transform.position.y + cameraOffset, player.transform.position.z), Color.green, 2, false);
		//currenty
		Debug.DrawLine (new Vector3 (player.transform.position.x + 1f, currentY, player.transform.position.z), new Vector3 (player.transform.position.x - 1f, currentY, player.transform.position.z), Color.red, 2, false);
		//nextY
		
	}


	//this method updata
	public IEnumerator  ResetCamera (float nextY, bool moving_plat) {

		if ((nextY > originY + cameraOffset) && !falling) {
			//nextY
			Debug.DrawLine (new Vector3 (player.transform.position.x + 3f, nextY, player.transform.position.z), new Vector3 (player.transform.position.x - 3f, nextY, player.transform.position.z), Color.green, 2, false);
		
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

		//when the position is updated closely follow the player
		on_moving_plat = moving_plat;
		diff_when_moving = Mathf.Abs (transform.position.y - player.transform.position.y);
		if (transform.position.y < player.transform.position.y) {
			diff_when_moving = -diff_when_moving;
		}

		currentY = transform.position.y;

	}

}
