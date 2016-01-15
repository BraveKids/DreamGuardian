using UnityEngine;
using System.Collections;

public class RainSpitterAI : MonoBehaviour {
    Animator anim;
    public GameObject cannonball;  
    float bulletTimer;
    public float shootInterval;
    public Transform shootPoint;

    public Transform target1;
    public Transform target2;
    public Transform target3;
    int selectedTarget = 1;
    public float shootAngle = 30;
    public bool isLeft;
    GameObject player;
    public GameObject toFlip;

    bool allowShoot;

    public Vector3 BallisticVel(Transform target, float angle)
    {
        var dir = target.position - shootPoint.transform.position;  // get target direction
        var h = dir.y;  // get height difference
        dir.y = 0;  // retain only the horizontal direction
        var dist = dir.magnitude;  // get horizontal distance
        var a = angle * Mathf.Deg2Rad;  // convert angle to radians
        dir.y = dist * Mathf.Tan(a);  // set dir to the elevation angle
        dist += h / Mathf.Tan(a);  // correct for small height differences
        // calculate the velocity magnitude
        var vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return vel * dir.normalized;
    }

    // Use this for initialization
    void Start()
    {
        allowShoot = false;
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((isLeft == true && player.transform.position.x > transform.position.x) || (isLeft == false && player.transform.position.x < transform.position.x))
        {
            Flip();
        }

        bulletTimer += Time.deltaTime;
        if (bulletTimer >= shootInterval)
        {
            allowShoot = true;
            bulletTimer = 0;
        }
        if (allowShoot == true)
        {
            allowShoot = false;
            anim.Play("Attack_RainSpitter");
            GameObject ball = Instantiate(cannonball, shootPoint.transform.position, Quaternion.identity) as GameObject;
            if (selectedTarget == 1)
            {
                ball.GetComponent<Rigidbody2D>().velocity = BallisticVel(target1, shootAngle);
            } 
            else if (selectedTarget == 2)
            {
                ball.GetComponent<Rigidbody2D>().velocity = BallisticVel(target2, shootAngle);
            }
            else if (selectedTarget == 3)
            {
                ball.GetComponent<Rigidbody2D>().velocity = BallisticVel(target3, shootAngle);
            }
            if (selectedTarget < 3)
            {
                selectedTarget++;
            }
            else
            {
                selectedTarget = 1;
            }
            
        }

    }
    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        isLeft = !isLeft;
    }
}
