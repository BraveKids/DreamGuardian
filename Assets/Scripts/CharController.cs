using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {
	
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

	
	// Update is called once per frame
	void FixedUpdate () {

		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (move));
		rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);
		if (move < 0 && !facingRight) {
			Flip ();
		} else if (move > 0 && facingRight)
			Flip ();
		
	}
	
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
}
