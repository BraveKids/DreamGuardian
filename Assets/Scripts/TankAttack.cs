using UnityEngine;
using System.Collections;

public class TankAttack : MonoBehaviour {

    TankAI tankAI;

    void Start()
    {
        tankAI = gameObject.GetComponentInParent<TankAI>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            tankAI.attacking = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            tankAI.attacking = false;
            tankAI.anim.SetBool("shield", false);

        }

    }
}
