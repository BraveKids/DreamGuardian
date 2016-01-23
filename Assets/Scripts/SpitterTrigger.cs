using UnityEngine;
using System.Collections;

public class SpitterTrigger : MonoBehaviour {

    SpitterAI spitterAI;
    public bool isForward;
    float exitInterval = 1.5f;
    float timer;
    bool isExit;

    void Start()
    {
        spitterAI = gameObject.GetComponentInParent<SpitterAI>();
    }

    void Update()
    {
        if (isExit == true)
        {
            checkExit();
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isForward == true)
            {
                spitterAI.attacking = true;
                isExit = false;
                timer = 0;
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
                isExit = true;
                spitterAI.attacking = false;
                
            }
            

        }

    }
    void checkExit()
    {
        timer += Time.deltaTime;
        if (timer >= exitInterval)
        {

            spitterAI.allowAttack = false;
            spitterAI.isInitial = true;
            spitterAI.bulletTimer = 0;
            timer = 0;
        }
    }
}
