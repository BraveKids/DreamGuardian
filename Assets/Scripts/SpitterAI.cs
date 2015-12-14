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
    

    public Transform BorderCheck;
    public float BorderCheckRadius;
    public LayerMask WhatIsBorder;
    public bool HittingBorder;

    float bulletTimer;
    float shootInterval = 2;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        bullet.transform.localScale = new Vector2(bullet.transform.localScale.x * -1, bullet.transform.localScale.y);
        walkVelocity *= -1;
        shootVelocity *= -1;

    }

    void Update()
    {
        if (attacking == false)
        {
            rb.isKinematic = false;
            rb.velocity = new Vector2(-walkVelocity, rb.velocity.y);
            walk();
        }
        else if (attacking == true)
        {
            rb.isKinematic = true;
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
        bulletTimer += Time.deltaTime;
        if (bulletTimer >= shootInterval)
        {
            GameObject bulletClone;
            bulletClone = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity) as GameObject;
            bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-shootVelocity, 0);
            bulletTimer = 0;
        }
    }
}
