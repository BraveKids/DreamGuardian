using UnityEngine;
using System.Collections;

public class TankAI : MonoBehaviour {

    float velocity = 1.5f;
    float backVelocity;
    Rigidbody2D rb;
    public Animator anim;
    public bool isLeft;
    public Transform player;
    public Transform startPosition;
    public Transform checkPosition;
    public float checkPositionRadius;
    public LayerMask WhatIsBorder;
    public bool HittingBorder;

    public bool inseguimento = false;
    public bool ritorno = false;

    float timer;
    public float vulnerabilityInterval;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        HittingBorder = Physics2D.OverlapCircle(checkPosition.position, checkPositionRadius, WhatIsBorder);
        BehaviourHandler();
   }

    void BehaviourHandler()
    {
        if ((isLeft == true && player.transform.position.x > checkPosition.transform.position.x) || (isLeft == false && player.transform.position.x < checkPosition.transform.position.x))
        {
            Flip();
        }
        if (inseguimento == true)
        {
            Move();
        }
        if (ritorno == true)
        {
            if (HittingBorder == false)
            {
                if ((isLeft == true && checkPosition.transform.position.x < startPosition.transform.position.x)||(isLeft == false && checkPosition.transform.position.x > startPosition.transform.position.x))
                {
                    GoBack();

                }
                else if ((isLeft == true && checkPosition.transform.position.x > startPosition.transform.position.x)||(isLeft == false && checkPosition.transform.position.x < startPosition.transform.position.x))
                {
                    Move();
                }
            }
            else if (HittingBorder == true)
            {
                Stop();
                ritorno = false;
            }
        }
    }

    public void Flip()
    {
        timer += Time.deltaTime;
        if (timer >= vulnerabilityInterval)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            velocity *= -1;
            isLeft = !isLeft;
            timer = 0;
        }
    }

    public void GoBack()
    {
        backVelocity = -velocity * (-1);
        rb.isKinematic = false;
        rb.velocity = new Vector2(backVelocity, rb.velocity.y);

    }

    public void Move()
    {
        rb.isKinematic = false;
        rb.velocity = new Vector2(-velocity, rb.velocity.y);
    }

    public void Stop()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        rb.isKinematic = true;
    }
}
