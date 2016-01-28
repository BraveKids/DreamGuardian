using UnityEngine;
using System.Collections;

public class TankAttack : MonoBehaviour {
	
TankAI tankAI;
Rigidbody2D rb;
void Start()
{
	tankAI = gameObject.GetComponentInParent<TankAI>();
	rb = gameObject.GetComponentInParent<Rigidbody2D> ();
}

void OnTriggerStay2D (Collider2D col)
{
	if (col.CompareTag("Player"))
	{
		rb.isKinematic = true;
		tankAI.attacking = true;
	}
}

void OnTriggerExit2D(Collider2D col)
{
	if (col.CompareTag("Player"))
	{
		tankAI.attacking = false;
		tankAI.allowHit = false;
		tankAI.anim.SetBool("shield", false);
		
	}
	
}
}