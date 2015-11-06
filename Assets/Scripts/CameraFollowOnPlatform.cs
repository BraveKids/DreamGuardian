using UnityEngine;
using System.Collections;

public class CameraFollowOnPlatform : MonoBehaviour {

	public static CameraFollowOnPlatform instance = null;
	Vector3 currentOrigin;
	public Vector3 nextOrigin;
	GameObject player;

	//su x
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
		float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		transform.position = new Vector3(posX, transform.position.y, transform.position.z);
		if (currentOrigin != nextOrigin) {
			StartCoroutine (ResetCamera ());
			currentOrigin = nextOrigin;
		}
	}

	IEnumerator  ResetCamera () {
		float transitionDuration = 2.5f;
		//some code
		float t = 0.0f;
		while (t < 1.0f) {
			t += Time.deltaTime * (Time.timeScale / transitionDuration);
			transform.position = Vector3.Lerp(currentOrigin,nextOrigin,t);		
			yield return 0;
		}


	}
}
