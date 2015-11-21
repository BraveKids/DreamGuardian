using UnityEngine;
using System.Collections;

public class PlayerAttackProv: MonoBehaviour {
	private bool attacking = false;
	private float attackTimer = 0;
	private float attackCd = 0.6f;
	private int combo = 0;
	public Collider2D attackTrigger1;
	public Collider2D attackTrigger2;
	public Collider2D attackTrigger3;
	public Collider2D superAttackTrigger;
	Animator anim;
	public int energy=0;
	
	void Awake (){
		anim = GetComponent<Animator>();
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
			
			
		}
		
		if (attacking) {
			
			if (attackTimer > 0 ) {
				attackTimer -= Time.deltaTime;
				if(Input.GetKeyDown("f")&& combo<3){
					combo +=1;
					
					//combo = combo%3;		
					anim.SetInteger("Combo", combo);
					if(combo>0 && combo<4){
						disablePrevCombo(combo);
						Invoke ("AttackTrigger"+combo, 0.1f);
						
					}
					attackTimer = attackCd;
				}
				
				
			} else {
				
				anim.SetInteger("Combo", 0);
				combo = 0;
				attacking = false;
				attackTrigger1.enabled = false;
				attackTrigger2.enabled = false;
				attackTrigger3.enabled = false;
				
				
			}
		}
		anim.SetBool ("Attacking", attacking);
	}
	
	void SuperAttack(){
		anim.SetTrigger ("SuperAttack");
		
		superAttackTrigger.enabled = true;
		Invoke("superAttackDown", 0.01f);
		
	}
	
	void disablePrevCombo(int comboCounter){
		if (comboCounter == 2) {
			attackTrigger1.enabled = false;
		} else {
			attackTrigger2.enabled = false;
		}
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

