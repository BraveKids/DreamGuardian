using UnityEngine;
using System.Collections;

public class ChaseZombieCone : MonoBehaviour {

    public bool isForward = false;
	public ZombieAI zombieAI;
	public GameObject zombie;
	// Use this for initialization

    void Start()
    {
		zombieAI  = gameObject.GetComponentInParent<ZombieAI>();
    }
    
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isForward == true)
            {

                zombieAI.Inseguimento = true;
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

            zombieAI.Inseguimento = false;

        }
    }
}
