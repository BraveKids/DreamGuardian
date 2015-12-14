using UnityEngine;
using System.Collections;

public class SpitterTrigger : MonoBehaviour {

    SpitterAI spitterAI;
    public bool isForward;

    void Start()
    {
        spitterAI = gameObject.GetComponentInParent<SpitterAI>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isForward == true)
            {
                spitterAI.attacking = true;
            }
            if (isForward == false)
            {
                spitterAI.Flip();
            }
            
        }
    
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isForward == true)
            {
                spitterAI.attacking = false;
            }
            

        }

    }
}
