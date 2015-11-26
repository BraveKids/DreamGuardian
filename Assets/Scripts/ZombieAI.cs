using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour {

    public Transform Player;
    public float velocity = 1.5f;
    Rigidbody2D rb;
    public Animator anim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    public void move()
    {
        rb.isKinematic = false;
        rb.velocity = new Vector2(-velocity, rb.velocity.y);
    }

    public void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        velocity *= -1;

    }

    public void stop()
    {
        rb.isKinematic = true;
    }

    
}
