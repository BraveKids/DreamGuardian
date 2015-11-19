using UnityEngine;
using System.Collections;

public class PlayerAttack: MonoBehaviour {
	private bool attacking = false;
	private float attackTimer = 0;
	private float attackCd = 1f;
	private int combo = 0;
	public Collider2D attackTrigger1;
	public Collider2D attackTrigger2;
	public Collider2D attackTrigger3;
	public Collider2D superAttackTrigger;
	private Animator anim;
	public int energy=0;
	void Awake (){
		anim = gameObject.GetComponent<Animator>();
		attackTrigger1.enabled = false;
		attackTrigger2.enabled = false;
		attackTrigger3.enabled = false;
		superAttackTrigger.enabled = false;
	}
	
	void Update() {
		if (energy==3 && Input.GetKey(KeyCode.B))
		{
			SuperAttack();
	
		}
		if(Input.GetKeyDown("f") && !attacking && anim.GetBool("Ground")==true){
			attacking = true;
			attackTimer= attackCd;
			if(combo>0 && combo<3){
			Invoke ("AttackTrigger"+combo, 0.1f);
			}


		}
		if (attacking) {
		
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
				if(Input.GetKeyDown("f")){
					combo +=1;
					anim.SetInteger("Combo", combo);
				}


			} else {
				combo = 0;
				anim.SetInteger("Combo", combo);
				attacking = false;
				attackTrigger1.enabled = false;
				attackTrigger2.enabled = false;
				attackTrigger3.enabled = false;

				
			}
		}
		anim.SetBool ("Attacking", attacking);
		anim.SetInteger("Combo", combo);
	
		
	}


	void SuperAttack(){
		anim.SetTrigger ("SuperAttack");
		
		superAttackTrigger.enabled = true;
		Invoke("superAttackDown", 0.2f);
	
	}


	void AttackTrigger1(){
		attackTrigger1.enabled = true;
	}
	void AttackTrigger2(){
		attackTrigger2.enabled = true;
	}
	void AttackTrigger3(){
		attackTrigger3.enabled = true;
	}
	void superAttackDown(){
		energy=-1;
		superAttackTrigger.enabled = false;
	}
	
}
