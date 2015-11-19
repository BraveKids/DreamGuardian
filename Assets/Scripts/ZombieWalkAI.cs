using UnityEngine;
using System.Collections;

public class ZombieWalkAI : MonoBehaviour {
    public float velocity = 1f;
    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();

    }

	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(- velocity, rb.velocity.y);
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Border")
        {
            transform.localScale = new Vector2(transform.localScale.x * -1 , transform.localScale.y);
            velocity *= -1;
        }
    }
}
