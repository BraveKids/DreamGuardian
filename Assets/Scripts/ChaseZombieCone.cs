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
    void Update()
    {

    }

    

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isForward == true)
            {
                zombieScript.move();
            }
            else if (isForward == false)
            {
                zombieScript.Flip();
                
            }
        }
        
            
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            zombieScript.stop();
        }
    }
}
