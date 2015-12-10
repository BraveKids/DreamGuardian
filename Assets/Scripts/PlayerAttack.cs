using UnityEngine;
using System.Collections;

public class PlayerAttack: MonoBehaviour {
	private bool attacking = false;

	private float hitTimer=0;
	private float lastHitTimer=0;
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
		hitTimer = Time.realtimeSinceStartup;





		if ((Input.GetKeyDown (KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.F)) &&  anim.GetBool ("Ground") == true) {
			lastHitTimer = Time.realtimeSinceStartup;
			if (combo > 3) {
				combo = 0;

			} else {
				combo++;
			}
			attacking = true;
			Combo (combo);
		}
			if (hitTimer - lastHitTimer > 0.5) {
				combo = 0;
				attacking = false;
				attackTrigger1.enabled = false;
				attackTrigger2.enabled = false;
				attackTrigger3.enabled = false;
				if (hitTimer - lastHitTimer < 0.2) {
					
					attacking = false;
					combo=0;
					Combo (0);

				} 
			}
			anim.SetBool ("Attacking", attacking);
			
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

