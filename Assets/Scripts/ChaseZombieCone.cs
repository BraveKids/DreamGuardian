using UnityEngine;
using System.Collections;

public class ChaseZombieCone : MonoBehaviour {

    public bool isForward = false;
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
            if (isForward == true)
            {
                zombieAI.move();
            }
            else if (isForward == false)
            {
                zombieAI.Flip();
                
            }
        }
        
            
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            zombieAI.stop();
        }
    }
}
