using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour {

    public GameObject Player;
    public Transform LeftBorder;
    public Transform RightBorder;
    public Collider2D AttackTrigger;
    ZombieDamage zombieDamage;

    public float walkVelocity = 1f;
    public float runVelocity = 1.8f;
    Rigidbody2D rb;
    public Animator anim;
    public bool Inseguimento = false;
    public bool IsLeft = true;
    bool stopped = false;
    public bool attacking = false;
    public bool hit = false;
    bool allowHit = false;

    public Transform BorderCheck;
    public float BorderCheckRadius;
    public LayerMask WhatIsBorder;
    public bool HittingBorder;
    float Range;

    float timer;
    float stopInterval = 1;
    float hitTimer;
    float hitInterval = 1;
    public bool ritorno = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        Range = BorderCheckRadius * 2;
        Player = GameObject.FindGameObjectWithTag("Player");
        AttackTrigger.enabled = false;
        zombieDamage = gameObject.GetComponentInChildren<ZombieDamage>();
    }

    public void Flip()
    {
        stopped = false;
        timer = 0;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkVelocity *= -1;
        runVelocity *= -1;
        IsLeft = !IsLeft;

    }

    void Update()
    {
        if (zombieDamage.allowAction == true)
        {
            if (attacking == true)
            {
                anim.SetBool("walking", false);
                if (allowHit == true)
                {
                    Attack();
                    //allowHit = false;
                }
                else if (allowHit == false)
                {
                    hit = false;
                    AttackTrigger.enabled = false;
                }
                hitTimer += Time.deltaTime;
                if (hitTimer >= hitInterval)
                {
                    allowHit = !allowHit;
                    hitTimer = 0;
                }

            }
            if (attacking == false)
            {
                hit = false;
                AttackTrigger.enabled = false;
            }
            if (stopped == true && attacking == false)
            {
                anim.SetBool("walking", false);
                rb.isKinematic = true;
                timer += Time.deltaTime;
                if (timer >= stopInterval)
                {
                    rb.isKinematic = false;
                    timer = 0;
                    stopped = false;
                    ritorno = true;
                }
            }

            if (Inseguimento == false && stopped == false && attacking == false)
            {
                anim.SetBool("walking", true);
                rb.velocity = new Vector2(-walkVelocity, rb.velocity.y);
                checkPosition();
            }
            else if (Inseguimento == true && stopped == false && attacking == false)
            {
                anim.SetBool("walking", true);
                rb.velocity = new Vector2(-runVelocity, rb.velocity.y);
            }
            anim.SetBool("attacking", hit);

        }
        else if (zombieDamage.allowAction == false)
        {

        }

    }

    public void checkPosition()
    {
        if (ritorno == true)
        {
            if ((BorderCheck.position.x > LeftBorder.position.x + Range) && (BorderCheck.position.x < RightBorder.position.x - Range))
            {
                walk();

            }
            else if ((BorderCheck.position.x < LeftBorder.position.x) && (IsLeft == true))
            {
                Flip();

            }
            else if ((BorderCheck.position.x > RightBorder.position.x) && (IsLeft == false))
            {
                Flip();
            }
        }
        
        /*else if ((BorderCheck.position.x < LeftBorder.position.x) && (IsLeft == false))
        {

        }
        else if ((BorderCheck.position.x > RightBorder.position.x) && (IsLeft == true))
        {

        }*/

    }

    public void walk()
    {
        HittingBorder = Physics2D.OverlapCircle(BorderCheck.position, BorderCheckRadius, WhatIsBorder);
        if (HittingBorder)
        {
            Flip();
        }
    }

    public void Stop()
    {
        stopped = true;
    }

    public void Attack()
    {
        rb.isKinematic = true;
        hit = true;
        AttackTrigger.enabled = true;
    }
    /*public void checkFlip()
    {
        if ((BorderCheck.position.x >Player.transform.position.x && IsLeft == false )|| (BorderCheck.position.x < Player.transform.position.x && IsLeft == true))
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            walkVelocity *= -1;
            runVelocity *= -1;
            IsLeft = !IsLeft;
        }
    }*/

}
