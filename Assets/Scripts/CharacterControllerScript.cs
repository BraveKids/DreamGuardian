using UnityEngine;
using System.Collections;

public class CharacterControllerScript : MonoBehaviour {

    public float maxSpeed;
	public int hp = 3;

    bool facingRight = true;
    public Rigidbody2D rb;
    Animator anim;
	public Collider2D attackTrigger;
	public Collider2D superAttackTrigger;
    bool groundedLeft = false;
	bool groundedRight = false;
	bool grounded = false;
	public Transform groundCheckLeft;
	public Transform groundCheckRight;
	float hitDelay = 1.5f;
	private float nextHitAllowed = 0f;
    float groundRadius = 0.1f;
    public LayerMask whatIsGround; //cosa il character deve considerare ground es. il terreno, i nemici...
    public float jumpForce;


    // Use this for initialization
    void Awake () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
    void Update()
    {
	
		Movement ();

    }

	void Movement(){

		if (grounded && Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool("Ground", false);
			rb.AddForce(new Vector2(0, jumpForce));
		}
		
		if (anim.GetBool ("Attacking") == false) {
			groundedLeft = Physics2D.OverlapCircle (groundCheckLeft.position, groundRadius, whatIsGround);
			groundedRight = Physics2D.OverlapCircle (groundCheckRight.position, groundRadius, whatIsGround);
			grounded = groundedLeft || groundedRight;
			anim.SetBool ("Ground", grounded); //per "capire" se è o no grounded, continua a chiederselo/ a verificarlo
			
			anim.SetFloat ("vSpeed", rb.velocity.y); //vertical speed
			
			float move = Input.GetAxis ("Horizontal");
			anim.SetFloat ("Speed", Mathf.Abs (move)); //con questa riga risco a "leggere" il mutamento di Speed
			// e quindi a far cambiare l'animazione da idle a run
			
			rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);
			
			if (move > 0 && !facingRight)
				Flip ();
			else if (move < 0 && facingRight)
				Flip ();
		}

	


	}

	
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

	void OnTriggerStay2D(Collider2D other) {
			if (other.CompareTag ("Enemy") && attackTrigger.enabled == false && superAttackTrigger.enabled== false && Time.time > nextHitAllowed) {

			hp -= 1;
			Debug.Log ("Danno " + hp + " left!");
			nextHitAllowed = Time.time + hitDelay;
			if (hp <= 0) {
				anim.SetTrigger ("death");
				Invoke ("Death", 0.8f);
			}
		}
		}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Death")) {
			Death();
		}
		
	}
	
	 void Death(){
		this.gameObject.SetActive (false);
	}
}
