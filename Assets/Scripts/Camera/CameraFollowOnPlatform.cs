using UnityEngine;
using System.Collections;

public class CameraFollowOnPlatform : MonoBehaviour {

	public static CameraFollowOnPlatform instance = null;
	Vector3 currentOrigin;	//posizione corrente della camera (transform.position), utilizzata per chiarezza del codice

	float currentY;		//l'ultima piattaforma toccata
	public float nextY;	//la piattaforma che si sta toccando
	GameObject player;


	private Vector2 velocity;
	public float smoothTimeX;

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

	void FixedUpdate () {
		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		transform.position = new Vector3 (posX, transform.position.y, transform.position.z);
		if (currentY != nextY) {
			StartCoroutine (ResetCamera ());
			currentY = nextY;
		}
		currentOrigin=transform.position;
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
