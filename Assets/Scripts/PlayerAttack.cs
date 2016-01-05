﻿using UnityEngine;
using System.Collections;

public class PlayerAttack: MonoBehaviour {
	public bool canAttack;
	private float hitTimer=0;
	private float lastHitTimer=0;
	private int combo = 0;
	public Collider2D attackTrigger1;
	public Collider2D attackTrigger2;
	public Collider2D attackTrigger3;
	public Collider2D attackJumpTrigger;
	public Collider2D superAttackTrigger;

	Rigidbody2D rb;
	Animator anim;

	public int energy=0;

	void Awake (){
		canAttack = true;
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		attackTrigger1.enabled = false;
		attackTrigger2.enabled = false;
		attackTrigger3.enabled = false;
		attackJumpTrigger.enabled = false;
		superAttackTrigger.enabled = false;
	}
	
	void Update() {
		hitTimer = Time.realtimeSinceStartup;





		if (canAttack &&(Input.GetKeyDown (KeyCode.Joystick1Button2) || Input.GetKeyDown (KeyCode.F)) && attackTrigger3.enabled == false) {
			if (anim.GetBool ("Ground") == true) {
				rb.velocity = new Vector3 (0f, 0f, 0f);
				anim.SetBool ("Attacking",true);
				lastHitTimer = Time.realtimeSinceStartup;
				if (combo > 3) {
					combo = 0;

				} else {
					combo++;
				}
			
				Combo (combo);
			
			}else{

				lastHitTimer = Time.realtimeSinceStartup;
				anim.Play ("YumeJumpAttack");
				attackJumpTrigger.enabled = true;
			}
		}
			if (hitTimer - lastHitTimer > 0.5) {
				combo = 0;
				Combo (0);

				if (hitTimer - lastHitTimer < 0.2) {
					

					combo=0;
					Combo (0);

				} 
			}
	
			
		}
	


	void Combo(int comboCounter){
			switch(comboCounter){
		case(1):
			anim.Play("YumeAttack1");

			attackTrigger1.enabled = true;
			attackTrigger2.enabled = false;
			attackTrigger3.enabled = false;

			break;
		case(2):
			anim.Play("YumeAttack2");
		
			attackTrigger1.enabled = false;
			attackTrigger2.enabled = true;
			attackTrigger3.enabled = false;
			break;
		case(3):
			anim.Play("YumeAttack3");
	
			attackTrigger1.enabled = false;
			attackTrigger2.enabled = false;
			attackTrigger3.enabled = true;
			break;
		default:

			attackTrigger1.enabled = false;
			attackTrigger2.enabled = false;
			attackTrigger3.enabled = false;
			attackJumpTrigger.enabled = false;
			anim.SetBool ("Attacking",false);
			break;

		}
	}


	void SuperAttack(){
		anim.SetTrigger ("SuperAttack");
		
		superAttackTrigger.enabled = true;
		Invoke("superAttackDown", 0.01f);
	
	}
	void superAttackDown(){
		energy=-1;
		superAttackTrigger.enabled = false;
	}


	
}

