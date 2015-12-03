/*using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	Rigidbody2D rb;
	float start_time = 0f;
	public float time_limit =  10f;
	private CharacterControllerScript characterScript;
	bool shoot = false;
 	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		characterScript = player.GetComponent ("CharacterControllerScript") as CharacterControllerScript;
		start_time = Time.time;
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (characterScript.facingRight == true && shoot == false) {
			rb.AddForce(new Vector2(300,0));
			shoot = true;

		} else if (characterScript.facingRight == false && shoot == false) {
			rb.AddForce(new Vector2(-300,0));
			shoot = true;
		}
			if (Time.time - start_time > time_limit) {
			GameObject.Destroy (this.gameObject);
			shoot = false;

		}
		
		
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Enemy") ) {
			Destroy(this.gameObject);
			shoot = false;
}
}
}
*/
