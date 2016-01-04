using UnityEngine;
using System.Collections;

public class TankAI : MonoBehaviour {

    float velocity = 1.5f;
    float backVelocity;
    Rigidbody2D rb;
    public Animator anim;
    public bool isLeft;
    public GameObject player;
    public Transform startPosition;
    public Transform checkPosition;
    public float checkPositionRadius;
    public LayerMask WhatIsBorder;
    public bool HittingBorder;

    public bool inseguimento = false;
    public bool ritorno = false;
    public bool vulnerable = false;

    float timer;
    public float vulnerabilityInterval;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
		anim = GetComponentInChildren<Animator> ();
        player = GameObject.FindGameObjectWithTag("Player");

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
            vulnerable = true;
            Flip();
        }
        if (inseguimento == true)
        {
            Move();
        }
        if (ritorno == true && vulnerable == false)
        {
            if (HittingBorder == false)
            {
                if ((isLeft == true && checkPosition.transform.position.x < startPosition.transform.position.x)||(isLeft == false && checkPosition.transform.position.x > startPosition.transform.position.x))
                {	
					anim.SetBool("walking",false);
                    GoBack();

                }
                else if ((isLeft == true && checkPosition.transform.position.x > startPosition.transform.position.x)||(isLeft == false && checkPosition.transform.position.x < startPosition.transform.position.x))
                {
                    Move();
                }
            }
            else if (HittingBorder == true)
            {
				anim.SetBool("walking",false);
                anim.SetBool("walkingBack", false);
                ritorno = false;
                Stop();
                
            }
        }
    }

    public void Flip()
    {
        anim.SetBool("walking", false);
        anim.SetBool("walkingBack", false);
        rb.isKinematic = true;
        timer += Time.deltaTime;
        if (timer >= vulnerabilityInterval)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            velocity *= -1;
            isLeft = !isLeft;
            vulnerable = false;
            rb.isKinematic = false;
            timer = 0;
        }
    }

    public void GoBack()
    {
        backVelocity = -velocity * (-1);
        rb.isKinematic = false;
        anim.SetBool("walkingBack", true);
        rb.velocity = new Vector2(backVelocity, rb.velocity.y);

    }

    public void Move()
    {
        rb.isKinematic = false;
		anim.SetBool ("walking", true);
        rb.velocity = new Vector2(-velocity, rb.velocity.y);
    }

    public void Stop()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        rb.isKinematic = true;
    }
}
