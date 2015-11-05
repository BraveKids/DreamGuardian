using UnityEngine;
using System.Collections;

public class CharacterControllerScript : MonoBehaviour {

    public float maxSpeed = 10f;
    bool facingRight = true;
    Rigidbody2D rb;
    Animator anim;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.1f;
    public LayerMask whatIsGround; //cosa il character deve considerare ground es. il terreno, i nemici...
    public float jumpForce = 70f;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
    void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
           anim.SetBool("Ground", false);
           rb.AddForce(new Vector2(0, jumpForce));
        }
    }


	void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded); //per "capire" se è o no grounded, continua a chiederselo/ a verificarlo

        anim.SetFloat("vSpeed", rb.velocity.y); //vertical speed

        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move)); //con questa riga risco a "leggere" il mutamento di Speed
                                                 // e quindi a far cambiare l'animazione da idle a run
       
        rb.velocity = new Vector2(move*maxSpeed,rb.velocity.y);

        if (move < 0 && !facingRight)
            Flip();
        else if (move > 0 && facingRight)
            Flip();
	}
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
