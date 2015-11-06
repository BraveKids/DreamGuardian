using UnityEngine;
using System.Collections;

public class PlayerAttack: MonoBehaviour {
	private bool attacking = false;
	private float attackTimer = 0;
	private float attackCd = 0.6f;
	public Collider2D attackTrigger;
	private Animator anim;
	void Awake (){
		anim = gameObject.GetComponent<Animator>();
		attackTrigger.enabled = false;
	}
	
	void Update() {
		if(Input.GetKeyDown("f") && !attacking){
			attacking = true;
			attackTimer= attackCd;
			Invoke ("Attack", 0.4f);

		}
		if (attacking){
			if(attackTimer>0){
				attackTimer-=Time.deltaTime;
			}
			else{
				attacking=false;
				attackTrigger.enabled = false;
			}
		}
		anim.SetBool("Attacking",attacking);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Enemy")) {
			//Destroy (other.gameObject);
			Debug.Log(other.ToString());
			other.gameObject.SetActive(false);
		}
	}

	void Attack(){
		attackTrigger.enabled = true;
	}
	
}