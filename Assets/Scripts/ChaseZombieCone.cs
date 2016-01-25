using UnityEngine;
using System.Collections;

public class ChaseZombieCone : MonoBehaviour {

    public bool isForward = false;
    ZombieAI zombieAI;
	public GameObject zombie;
    public bool checking = false;
	// Use this for initialization

    void Start()
    {
		zombieAI  = gameObject.GetComponentInParent<ZombieAI>();
    }

   /* void Update()
    {
        if (checking == true)
        {
            zombieAI.checkFlip();
        }
        else if (checking == false)
            {

            }

    }*/
    
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isForward == true)
            {
                zombieAI.Inseguimento = true;
                zombieAI.ritorno = false;
            }
            else if (isForward == false)
            {
                zombieAI.ritorno = false;
                zombieAI.Flip();

                //checking = true;

            }
        }
        
            
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isForward == true)
            {
                zombieAI.Stop();
                zombieAI.Inseguimento = false;
                //zombieAI.ritorno = true;
            }
            else if (isForward == false)
            {
                //zombieAI.ritorno = true;
            }


        }
    }
}
