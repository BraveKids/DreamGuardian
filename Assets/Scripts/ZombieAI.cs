using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour {

    public Transform Player;
    public Transform LeftBorder;
    public Transform RightBorder;
    float velocity = 1f;
    Rigidbody2D rb;
    public Animator anim;
    public bool Inseguimento = false;
    public bool GoBack = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    public void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        velocity *= -1;

    }

    void Update()
    {
        if ((transform.position.x < RightBorder.position.x) && (transform.position.x > LeftBorder.position.x) && (Inseguimento == false) && (GoBack == true))
        {
            GoBack = false;
        }

        if ((Inseguimento == false) && (GoBack == false) && ((transform.position.x <= LeftBorder.position.x) || (transform.position.x >= RightBorder.position.x)))
        {
            Flip();
        }
        rb.velocity = new Vector2(-velocity, rb.velocity.y);
    }

    public void move()
    {
        Inseguimento = true;
        GoBack = false;
    }

    

    public void stop()
    {
        Inseguimento = false;
        GoBack = true;
        if ((transform.position.x < LeftBorder.position.x) && (rb.velocity.x < 0) && (GoBack == true))
        {
            Flip();
        }
        if ((transform.position.x > RightBorder.position.x) && (rb.velocity.x > 0) && (GoBack == true))
        { 
            Flip();
        }
        

    }

   

}
