using UnityEngine;
using System.Collections;

public class FlyingSpitterAI : MonoBehaviour {

    public GameObject character;
    public float moveSpeed;
    public Transform currentPoint;
    public Transform[] points;
    public int pointSelection;

    public float bulletTimer;
    public float shootInterval;
    public GameObject bullet;
    public Transform shootPoint;
    public float bulletSpeed;
	Animator anim;
    public bool isLeft;
    GameObject player;
    public bool allowAttack = true;
    public float initialInterval;
    public bool isInitial = true;

    public bool attackSpitter;

    // Use this for initialization
    void Start()
    {
        currentPoint = points[pointSelection];
        player = GameObject.FindGameObjectWithTag("Player");
		anim = GetComponentInChildren<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {

		character.transform.position = Vector3.MoveTowards(character.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
        if (character.transform.position == currentPoint.position)
        {
            pointSelection++;

            if (pointSelection == points.Length)
            {
                pointSelection = 0;
            }

            currentPoint = points[pointSelection];
        }
        if ((isLeft == true && player.transform.position.x > transform.position.x)|| (isLeft == false && player.transform.position.x < transform.position.x))
        {
            Flip();
        }
    }
    public void Attack()
    {
        if (attackSpitter == true)
        {
            if (allowAttack == true)
            {
                anim.Play("Attack");
                GameObject bulletClone;
                if (isLeft == true)
                {
                    bulletClone = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity) as GameObject;
                    bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0);
                    allowAttack = false;
                }
                else if (isLeft == false)
                {
                    bullet.transform.localScale = new Vector2(bullet.transform.localScale.x * -1, bullet.transform.localScale.y);
                    bulletClone = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity) as GameObject;
                    bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0);
                    bullet.transform.localScale = new Vector2(bullet.transform.localScale.x * -1, bullet.transform.localScale.y);
                    allowAttack = false;
                }
            }
            else if (allowAttack == false)
            {
                if (isInitial == true)
                {
                    bulletTimer += Time.deltaTime;
                    if (bulletTimer >= initialInterval)
                    {

                        bulletTimer = 0;
                        allowAttack = true;
                        isInitial = false;
                    }
                }
                else if (isInitial == false)
                {
                    bulletTimer += Time.deltaTime;
                    if (bulletTimer >= shootInterval)
                    {

                        bulletTimer = 0;
                        allowAttack = true;
                    }
                }
                
            }
            else if (attackSpitter == false)
            {
                
            }
        }
               
    }
    
    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        isLeft = !isLeft;
        bulletSpeed *= -1;
    }
}
