using UnityEngine;
using System.Collections;
using System.Linq;

public class CameraFollowOnPlatform : MonoBehaviour {

	private bool followYume = true;
	public static CameraFollowOnPlatform instance = null;
	Vector3 currentOrigin;	//posizione corrente della camera (transform.position), utilizzata per chiarezza del codice

	public float originY;	//basically the ground y
	public bool nextToGround = true;
	public GameObject player;
	public float cameraOffset = 1.5f;	//when on ground how much the camera will be lift up from it?

	public float deviationFix = 0.2f; //if i jump on the spot i get different y position. Fixed it introducing a little range between odl and new position

	//used for ResetCamera, no need to explain
	private Vector2 velocity;
	public float smoothTimeX;
	public float smoothTimeY;
	float t = 0.0f;
	public bool onMovingPlat = false;
	bool movingCamera = false;
	public float nextY;

	//when on moving platform some time is needed to move vertically the camera, and then 
	//the camera will follow the platform. This generate some space lap.
	public float diff_when_moving = 0;
	private bool onVerticalLevel = false;
	private bool onChasingCamera = false;
	float playerY;
	float playerX;
	float cameraX;
	float cameraY;
	Camera cam;
	float height ;
	float width;
	bool twisted;

	//chasing camera speed
	public float moveSpeed = 1;

	public void Start () {
		setChasingCamera (false);
		twisted = false;
		cam = Camera.main;
		height = 2f * cam.orthographicSize;
		width = height * cam.aspect;

		// singleton
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}

		player = GameObject.FindGameObjectWithTag ("Player");
		currentOrigin = new Vector3 (player.transform.position.x, player.transform.position.y + cameraOffset, transform.position.z);
		transform.position = currentOrigin;
	}

	void Update () {
		if (followYume) {
			player = GameObject.FindGameObjectWithTag ("Player");


			playerX = player.transform.position.x;
			playerY = player.transform.position.y;

			Debug.DrawLine (new Vector3 (player.transform.position.x, transform.position.y + deviationFix, player.transform.position.z), new Vector3 (player.transform.position.x, transform.position.y - deviationFix, player.transform.position.z), Color.green, 2, false);
			Debug.DrawLine (new Vector3 (-100f, originY, player.transform.position.z), new Vector3 (100f, originY, player.transform.position.z), Color.green, 2, false);
			
			cameraX = player.transform.position.x;
			
			if (onChasingCamera) {
				cameraX = transform.position.x;
			}

			cameraY = transform.position.y;
		
			if (playerY < originY + cameraOffset) {
				nextToGround = true;
			} else {
				nextToGround = false;
			}


			//if on moving platform

			if (onMovingPlat && !nextToGround) {
				cameraY = player.transform.position.y + diff_when_moving;
				nextY = cameraY;
			}


			if (!onVerticalLevel) {
				//if falling
				//if i'm out of range and also lower from the bottom then i'm falling
				if (imFalling (playerY, nextY - deviationFix, nextY + deviationFix) && !nextToGround) {
					float diff = cameraY - playerY;
					movingCamera = false;
					cameraY = playerY /*+ diff*/;
				}
			} else {	// if on vertical level when player goes down the camera dies!
				if (playerY < cameraY - (height / 2)) {
					player.GetComponent<CharacterControllerScript> ().Death ();
				}
			}


			if (onChasingCamera) {
				if (playerX < cameraX - width / 2) { //if camera "eats" me
					player.GetComponent<CharacterControllerScript> ().Death ();					
				}

				//move the camera to the end of the camera, so basically go forward
				Vector3 cameraEnd = new Vector3 (cameraX + width / 2, cameraY, transform.position.z);
				cameraX = Vector3.MoveTowards (transform.position, cameraEnd, Time.deltaTime * moveSpeed).x;
			}
		
	

			transform.position = new Vector3 (cameraX, cameraY, transform.position.z);



			//only used for ResetCamera
			currentOrigin = transform.position;

		}
		
	}

	public void followMe (float nextY, bool movingPlat) {
		
		if (onVerticalLevel && nextY < this.nextY) {
			return;
		}

		if (this.nextY < nextY) {
			this.nextY = nextY;
			if (movingCamera) {
				t = 0.0f;
			} else {
				StartCoroutine (ResetCamera (movingPlat));

			}
		}

	}

	public IEnumerator  ResetCamera (bool movingPlat) {


		//Debug.DrawLine (new Vector3 (player.transform.position.x + 1f, currentY, player.transform.position.z), new Vector3 (player.transform.position.x - 1f, currentY, player.transform.position.z), Color.red, 2, false);
		movingCamera = true;
		//if nextY is greater than the origin plus offset due to moving platform, don't move the camera
		bool substantialDiff = outOfRange (nextY, transform.position.y - deviationFix, transform.position.y + deviationFix);

		if (substantialDiff && !nextToGround) {

			t = 0.0f;
			float transitionDuration = 1f;
			//some code
			while (t < 1.0f && movingCamera) {
				t += Time.deltaTime * (Time.timeScale / transitionDuration);
				//Vector3 nextPos = new Vector3 (transform.position.x, nextY, transform.position.z);
				Vector3 nextPos = new Vector3 (transform.position.x, nextY, transform.position.z);

				//don't know why but it seems like it take less than transitionDuration to set the camera so i forced the exit

				transform.position = Vector3.Lerp (transform.position, nextPos, t);	
				if (nextY == transform.position.y) {
					movingCamera = false;
				}
				yield return 0;
			}
		}

		if (movingPlat) {

			diff_when_moving = Mathf.Abs (transform.position.y - player.transform.position.y);
			if (transform.position.y < player.transform.position.y) {
				diff_when_moving = -diff_when_moving;
			}

		}

		onMovingPlat = movingPlat;

		
		movingCamera = false;

	}

	bool outOfRange (float numberToCheck, float bottom, float top) {
		return numberToCheck < bottom || numberToCheck > top;
	}

	bool imFalling (float playerY, float bottom, float top) {
		return outOfRange (playerY, bottom, top) && playerY < bottom;
	}
	
	public void stopCourutine () {
		StopCoroutine ("ResetCamera");
	}

	public void setFollowYume (bool follow) {
		this.followYume = follow;
	}

	public void setChasingCamera (bool chasing) {

		transform.FindChild ("cameraBorder").gameObject.SetActive (chasing);
		transform.FindChild ("chasingSmoke").gameObject.SetActive (chasing);

		this.onChasingCamera = chasing;
	}

	public bool getChasingCamera () {
		return onChasingCamera;
	}

	public void setFollowYume (bool follow, Vector3 position) {
		this.followYume = follow;
		transform.position = new Vector3 (position.x /*- diffOnNewLevel*/, position.y + cameraOffset, transform.position.z);
	}

	public void verticalLevel (bool vertical) {
		onVerticalLevel = vertical;
	}

	public void onNewLevel (Vector3 position) {
		setFollowYume (false, new Vector3 (position.x, player.transform.position.y, position.z));	

	}

	public void setOriginY (float originY) {
		this.originY = originY;
	}

	public void dreamTwist (bool twist) {
		if (twist && !twisted) {
			transform.rotation = Quaternion.Euler(new Vector3(0, 180f, 180f));
			transform.position = new Vector3 (cameraX, cameraY, 10f);			
			Debug.Log ("camera twisted");
		}

		if (!twist && twisted) {
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
			
			transform.position = new Vector3 (cameraX, cameraY, -10f);
			Debug.Log ("Back to normal");
			
		}

		twisted = twist;
		
		
		//transform.position = new Vector3(0,0, -cam.transform.position.z);

	}
}
