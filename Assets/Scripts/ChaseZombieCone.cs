using UnityEngine;
using System.Collections;

public class ChaseZombieCone : MonoBehaviour {

    public bool isLeft = false;
    public ZombieAI zombieAI;

    void Start()
    {
        zombieAI = gameObject.GetComponentInParent<ZombieAI>();
    }
    void Update()
    {

    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isLeft)
            {
                zombieAI.chaseLeft();
            }
            else
            {
                zombieAI.chaseRight();
            }
        }
    }
}
