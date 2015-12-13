using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour {

    public GameObject Player;
    public Transform LeftBorder;
    public Transform RightBorder;
    public Collider2D AttackTrigger;

    float walkVelocity = 1f;
    float runVelocity = 1.8f;
    Rigidbody2D rb;
    public Animator anim;
    public bool Inseguimento = false;
    public bool IsLeft = true;
    bool stopped = false;
    public bool attacking = false;
    public bool hit = false;

    public Transform BorderCheck;
    public float BorderCheckRadius;
    public LayerMask WhatIsBorder;
    public bool HittingBorder;
    float Range;

    float timer;
    float stopInterval = 2;
    float hitTimer;
    float hitInterval = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        Range = BorderCheckRadius * 2;
        Player = GameObject.FindGameObjectWithTag("Player");
        AttackTrigger.enabled = false;
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
        if (stopped == true)
        {
            rb.isKinematic = true;
            timer += Time.deltaTime;
            if (timer >= stopInterval)
            {
                rb.isKinematic = false;
                timer = 0;
                stopped = false;
            }
        }
        if (attacking == true)
        {
            Attack();
        }
        else if (attacking == false)
        {
            rb.isKinematic = false;
            AttackTrigger.enabled = false;
        hit = false;

        }
        if (Inseguimento == false && stopped == false && attacking == false)
        {
            rb.velocity = new Vector2(-walkVelocity, rb.velocity.y);
            checkPosition();
        }
        else if (Inseguimento == true && stopped == false && attacking == false)
        {
            rb.velocity = new Vector2(-runVelocity, rb.velocity.y);
        }
        anim.SetBool("attacking", hit);

    }

    public void checkPosition()
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
        else if ((BorderCheck.position.x < LeftBorder.position.x) && (IsLeft == false))
        {

        }
        else if ((BorderCheck.position.x > RightBorder.position.x) && (IsLeft == true))
        {

        }

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

    void Attack()
    {
        rb.isKinematic = true;
        hitTimer += Time.deltaTime;
        if (hitTimer >= hitInterval)
        {
            AttackTrigger.enabled = true;
            hit = true;
            timer = 0;

        }
        
    }
}
