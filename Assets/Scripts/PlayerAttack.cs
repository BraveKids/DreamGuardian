using UnityEngine;
using System.Collections;

public class PlayerAttack: MonoBehaviour {
	private bool attacking = false;
	private float attackTimer = 0;
	private float attackCd = 0.8f;
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
			Invoke ("Attack", 0.1f);

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


	void Attack(){
		attackTrigger.enabled = true;
	}

	}
	
