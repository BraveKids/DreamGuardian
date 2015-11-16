using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour {

    public Transform Player;
    public float MoveSpeed = 4;
    public bool isLeft = false;

    /* void Update()
     {
         float move = Input.GetAxis("Horizontal");
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
     } */

    public void chaseLeft()
    {
        transform.position -= transform.right * MoveSpeed * Time.deltaTime;
    }
    public void chaseRight()
    {
        transform.position += transform.right * MoveSpeed * Time.deltaTime;
    }

    public void Flip()
    {
        isLeft = !isLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
