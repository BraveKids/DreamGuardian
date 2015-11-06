using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour {
	public Collider2D damageArea;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Enemy")) {
			Debug.Log ("DANNO");
		}
	}
}
