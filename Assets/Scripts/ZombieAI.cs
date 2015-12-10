using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour {

    public GameObject Player;
    public Transform LeftBorder;
    public Transform RightBorder;

    float walkVelocity = 1f;
    float runVelocity = 1.8f;
    Rigidbody2D rb;
    public Animator anim;
    public bool Inseguimento = false;
    public bool IsLeft = true;

    public Transform BorderCheck;
    public float BorderCheckRadius;
    public LayerMask WhatIsBorder;
    public bool HittingBorder;
    float Range;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Range = BorderCheckRadius * 2;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkVelocity *= -1;
        runVelocity *= -1;
        IsLeft = !IsLeft;

    }

    void Update()
    {
        if (Inseguimento == false)
        {
            rb.velocity = new Vector2(-walkVelocity, rb.velocity.y);
            checkPosition();
        }
        else if (Inseguimento == true)
        {
            rb.velocity = new Vector2(-runVelocity, rb.velocity.y);
        }
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
}
