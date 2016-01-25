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
    public Collider2D AttackTrigger;
    public bool HittingBorder;

    public bool inseguimento = false;
    public bool ritorno = false;
    public bool vulnerable = false;

    float timer;
    public float vulnerabilityInterval;
    float hitTimer;
    float hitInterval = 2;
    float attackInterval = 1;
    float attackTimer;

    public bool attacking = false;
    bool activateTrigger = true;
    bool allowHit = false;
    public bool shieldIsActive = false;
    ZombieDamage zombieDamage;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
		anim = GetComponentInChildren<Animator> ();
        player = GameObject.FindGameObjectWithTag("Player");
        AttackTrigger.enabled = false;
        zombieDamage = gameObject.GetComponentInChildren<ZombieDamage>();
    }
	
	// Update is called once per frame
	void Update () {
        if (zombieDamage.allowAction == true)
        {
            HittingBorder = Physics2D.OverlapCircle(checkPosition.position, checkPositionRadius, WhatIsBorder);
            BehaviourHandler();
        }
        else if (zombieDamage.allowAction == false)
        {

        }
       
   }

    void BehaviourHandler()
    {
       
            if (attacking == true)
            {
                //anim.SetBool("walking", false);
                anim.SetBool("walkingBack", false);
                anim.SetBool("shield", true);
                if (allowHit == true)
                {
                    Attack();
                }
                else if (allowHit == false)
                {
                    AttackTrigger.enabled = false;
                }
                hitTimer += Time.deltaTime;
                if (hitTimer >= hitInterval)
                {
                    allowHit = true;
                    hitTimer = 0;
                }

            }
            if (attacking == false)
            {
                AttackTrigger.enabled = false;
                anim.SetBool("shield", false);
            }
            if (attacking == false)
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
                        if ((isLeft == true && checkPosition.transform.position.x < startPosition.transform.position.x) || (isLeft == false && checkPosition.transform.position.x > startPosition.transform.position.x))
                        {
                            anim.SetBool("walking", false);
                            GoBack();

                        }
                        else if ((isLeft == true && checkPosition.transform.position.x > startPosition.transform.position.x) || (isLeft == false && checkPosition.transform.position.x < startPosition.transform.position.x))
                        {
                            Move();
                        }
                    }
                    else if (HittingBorder == true)
                    {
                        anim.SetBool("walking", false);
                        anim.SetBool("walkingBack", false);
                        ritorno = false;
                        Stop();

                    }
                }
            }
    }

    public void Flip()
    {
        anim.SetBool("walking", false);
        anim.SetBool("walkingBack", false);
        rb.isKinematic = true;
        timer += Time.deltaTime;
        if (timer >= vulnerabilityInterval && zombieDamage.allowAction == true)
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

    public void Attack()
    {
        rb.isKinematic = true;
        AttackTrigger.enabled = true;
        if (activateTrigger == true)
        {
            anim.SetBool("walking", false);
            anim.SetBool("shield", false);
            anim.SetTrigger("attack");
            activateTrigger = false;
        }
        
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackInterval)
        {
            allowHit = false;
            activateTrigger = true;
            attackTimer = 0;
        }
            
    }
}
