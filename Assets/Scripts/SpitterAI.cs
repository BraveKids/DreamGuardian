using UnityEngine;
using System.Collections;

public class SpitterAI : MonoBehaviour {

    GameObject Player;
    public Transform LeftBorder;
    public Transform RightBorder;
    public Transform shootPoint;
    public GameObject bullet;

    float walkVelocity = 1f;
    float shootVelocity = 1.8f;
    Rigidbody2D rb;
    public Animator anim;
    
    public bool attacking = false;
    public bool isLeft;
    

    public Transform BorderCheck;
    public float BorderCheckRadius;
    public LayerMask WhatIsBorder;
    public bool HittingBorder;

    float bulletTimer;
    float shootInterval = 1;

    public bool attackSpitter;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        //bullet.transform.localScale = new Vector2(bullet.transform.localScale.x * -1, bullet.transform.localScale.y);
        walkVelocity *= -1;
        shootVelocity *= -1;
        isLeft = !isLeft;

    }

    void Update()
    {
        if (attacking == false)
        {
			anim.SetBool("Attacking", attacking);
            rb.isKinematic = false;
            rb.velocity = new Vector2(-walkVelocity, rb.velocity.y);
            walk();
        }
        else if (attacking == true)
        {
			anim.SetBool("Attacking", attacking);
            rb.isKinematic = true;
			rb.velocity = new Vector2(0f,0f);
            Attack();
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

    public void Attack()
    {
        if (attackSpitter == true)
        {
            bulletTimer += Time.deltaTime;
            if (bulletTimer >= shootInterval)
            {
                anim.Play("Attack");
                GameObject bulletClone;
                if (isLeft == true)
                {
                    bulletClone = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity) as GameObject;
                    bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-shootVelocity, 0);
                    bulletTimer = 0;
                }
                else if (isLeft == false)
                {
                    bullet.transform.localScale = new Vector2(bullet.transform.localScale.x * -1, bullet.transform.localScale.y);
                    bulletClone = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity) as GameObject;
                    bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-shootVelocity, 0);
                    bullet.transform.localScale = new Vector2(bullet.transform.localScale.x * -1, bullet.transform.localScale.y);
                    bulletTimer = 0;
                }
                /*bulletClone = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-shootVelocity, 0);
                bulletTimer = 0;*/
            }
        }
        else if (attackSpitter == false)
        {

        }
        
    }
}
