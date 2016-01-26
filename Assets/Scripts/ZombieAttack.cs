using UnityEngine;
using System.Collections;

public class ZombieAttack : MonoBehaviour {

    ZombieAI zombieAI;
	Rigidbody2D rb;
    void Start()
    {
        zombieAI = gameObject.GetComponentInParent<ZombieAI>();
		rb = gameObject.GetComponentInParent<Rigidbody2D> ();
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
			rb.isKinematic = true;
            zombieAI.attacking = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            zombieAI.attacking = false;

        }

    }
}
