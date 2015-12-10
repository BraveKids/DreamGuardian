using UnityEngine;
using System.Collections;

public class ChaseZombieCone : MonoBehaviour {

    public bool isForward = false;
	private ZombieAI zombieScript;
	public GameObject zombie;
	// Use this for initialization

    void Start()
    {
		zombieScript  = zombie.gameObject.GetComponent("ZombieAI") as ZombieAI;
    }
    
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isForward == true)
            {
<<<<<<< HEAD
                zombieScript.move();
            }
            else if (isForward == false)
            {
                zombieScript.Flip();
                
=======
                zombieAI.Inseguimento = true;
            }
            else if (isForward == false)
            {
                zombieAI.Flip();

>>>>>>> IA
            }
        }
        
            
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
<<<<<<< HEAD
            zombieScript.stop();
=======
            zombieAI.Inseguimento = false;

>>>>>>> IA
        }
    }
}
