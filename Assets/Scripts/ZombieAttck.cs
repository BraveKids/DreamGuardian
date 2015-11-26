using UnityEngine;
using System.Collections;

public class ZombieAttck : MonoBehaviour {

    public ZombieAI zombieAI;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.collision=="box")
        {
            //zombieAI.stop();
            zombieAI.anim.SetBool("Attacking", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            zombieAI.anim.SetBool("Attacking", false);
        }
    }
}

