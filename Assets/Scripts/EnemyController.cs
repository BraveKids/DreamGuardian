using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	Animator anim;
	public float hp = 4;
	private PlayerAttack playerScript;
	 GameObject player;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerScript = player.gameObject.GetComponent("PlayerAttack") as PlayerAttack;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("AttackTrigger")) {
			hp -= 1;
			if(playerScript.energy<3){
			playerScript.energy += 1;
			}
			anim.SetTrigger ("damage");
			Debug.Log ("OUCH! " + hp + " left!");
			if (hp <= 0) {
				anim.SetTrigger ("explode");
				DestroyEnemy();
			}
		}
		if (other.CompareTag ("SuperAttackTrigger")) {
				anim.SetTrigger ("explode");
				DestroyEnemy();
			}
		}


	void DestroyEnemy(){
		this.gameObject.SetActive (false);
	}
}
