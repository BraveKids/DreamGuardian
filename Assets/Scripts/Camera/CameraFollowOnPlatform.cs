using UnityEngine;
using System.Collections;

public class CameraFollowOnPlatform : MonoBehaviour {

	public static CameraFollowOnPlatform instance = null;
	Vector3 currentOrigin;	//posizione corrente della camera (transform.position), utilizzata per chiarezza del codice

	public float currentY;		//l'ultima piattaforma toccata
	public float nextY;	//la piattaforma che si sta toccando
	GameObject player;
	public float groundDim = 1.5f;
	private Vector2 velocity;
	public float smoothTimeX;
	public float smoothTimeY;

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
		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z);
		float posY = transform.position.y;

		//if I land on a platform
		if (currentY != nextY) {
			StartCoroutine (ResetCamera ());
			currentY = nextY;
		}

		//if i'm falling
		if (player.transform.position.y + groundDim < currentY) {
			posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y + groundDim, ref velocity.y, smoothTimeY);
			posY = player.transform.position.y + groundDim;
			currentY = player.transform.position.y + groundDim;
			nextY = player.transform.position.y + groundDim;
			
		}
		transform.position = new Vector3 (posX, posY, transform.position.z);

		
		currentOrigin = transform.position;
		//player + ground dim
		Debug.DrawLine (new Vector3 (player.transform.position.x + 0.5f, player.transform.position.y + groundDim, player.transform.position.z), new Vector3 (player.transform.position.x - 0.5f, player.transform.position.y + groundDim, player.transform.position.z), Color.green, 2, false);
		//currenty
		Debug.DrawLine (new Vector3 (player.transform.position.x + 1f, currentY, player.transform.position.z), new Vector3 (player.transform.position.x - 1f, currentY, player.transform.position.z), Color.red, 2, false);
		//nextY
		Debug.DrawLine (new Vector3 (player.transform.position.x + 3f, nextY, player.transform.position.z), new Vector3 (player.transform.position.x - 3f, nextY, player.transform.position.z), Color.green, 2, false);
		
	}

	IEnumerator  ResetCamera () {
		float transitionDuration = 1f;
		//some code
		float t = 0.0f;
		while (t < 1.0f) {
			t += Time.deltaTime * (Time.timeScale / transitionDuration);
			Vector3 nextPos = new Vector3 (transform.position.x, nextY, transform.position.z);
			transform.position = Vector3.Lerp (currentOrigin, nextPos, t);		
			yield return 0;
		}

		currentY = nextY;


	}
}
