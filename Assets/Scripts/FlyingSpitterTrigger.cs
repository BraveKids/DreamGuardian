using UnityEngine;
using System.Collections;

public class FlyingSpitterTrigger : MonoBehaviour
{
    public FlyingSpitterAI flyingSpitterAI;
    float exitInterval = 1.5f;
    float timer;
    bool isExit;

    void Start()
    {
        flyingSpitterAI = gameObject.GetComponentInParent<FlyingSpitterAI>();
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
            flyingSpitterAI.Attack();
            isExit = false;
            timer = 0;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isExit = true;

        }
    }
    void checkExit()
    {
        timer += Time.deltaTime;
        if (timer >= exitInterval)
        {

            flyingSpitterAI.allowAttack = false;
            flyingSpitterAI.isInitial = true;
            flyingSpitterAI.bulletTimer = 0;
            timer = 0;
        }
    }

}
