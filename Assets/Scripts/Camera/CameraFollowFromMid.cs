using UnityEngine;
using System.Collections;



public class CameraFollowFromMid : MonoBehaviour {

	public static CameraFollowFromMid instance = null;

    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject player;
    public GameObject terrain;

    public Vector3 origin;



    void Start() {
		// singleton
		if (instance==null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
        player = GameObject.FindGameObjectWithTag("Player");
        origin = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        transform.position = origin;

    }



    void FixedUpdate() {

        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float destY = origin.y;
        if (player.transform.position.y > origin.y) { destY = player.transform.position.y; }
        float posY = Mathf.SmoothDamp(transform.position.y, destY, ref velocity.y, smoothTimeY);
        transform.position = new Vector3(posX, posY, transform.position.z);
    }


}


