using UnityEngine;
using System.Collections;

public class PlayerAttack: MonoBehaviour {
	private bool attacking = false;
	private float attackTimer = 0;
	private float attackCd = 0.8f;
	public Collider2D attackTrigger;
	public Collider2D superAttackTrigger;
	private Animator anim;
	public int energy=0;
	void Awake (){
		anim = gameObject.GetComponent<Animator>();
		attackTrigger.enabled = false;
		superAttackTrigger.enabled = false;
	}
	
	void Update() {
		if (energy==3 && Input.GetKeyDown(KeyCode.B))
		{

			anim.SetTrigger ("SuperAttack");

			superAttackTrigger.enabled = true;
			Invoke("superAttackDown", 0.2f);

		}
		if(Input.GetKeyDown("f") && !attacking){
			attacking = true;
			attackTimer= attackCd;
			Invoke ("Attack", 0.1f);

		}
		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attacking = false;
				attackTrigger.enabled = false;
			}
		}
		anim.SetBool ("Attacking", attacking);
	}



	void Attack(){
		attackTrigger.enabled = true;
	}
	void superAttackDown(){
		energy=-1;
		superAttackTrigger.enabled = false;
	}
	
}
