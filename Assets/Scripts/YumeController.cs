using UnityEngine;
using System.Collections;

public class YumeController : MonoBehaviour {
	
	public float maxSpeed = 10f;
	private bool facingRight = true;
	Animator anim;
	Rigidbody2D rb;
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	
	
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	void Update(){
			if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool ("Ground",false);
			rb.AddForce(new Vector2(0, jumpForce));
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
		anim.SetFloat ("vSpeed", rb.velocity.y);

		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (move));
		rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);
		if (move > 0 && !facingRight) {
			Flip ();
		} else if (move < 0 && facingRight)
			Flip ();
		
	}
	
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
}
