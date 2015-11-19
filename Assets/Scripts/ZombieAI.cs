using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour {

    public Transform Player;
    public float MoveSpeed = 4;
    public bool isLeft = false;

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
