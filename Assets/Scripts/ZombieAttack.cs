using UnityEngine;
using System.Collections;

public class ZombieAttack : MonoBehaviour {

    ZombieAI zombieAI;

    void Start()
    {
        zombieAI = gameObject.GetComponentInParent<ZombieAI>();
    }

    void OnTriggerStay2D (Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
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
