using UnityEngine;
using System.Collections;

public class FlyingSpitterAI : MonoBehaviour {

    public GameObject character;
    public float moveSpeed;
    public Transform currentPoint;
    public Transform[] points;
    public int pointSelection;

    float bulletTimer;
    public float shootInterval;
    public GameObject bullet;
    public Transform shootPoint;
    public float bulletSpeed;

    public bool isLeft;
    GameObject player;

    // Use this for initialization
    void Start()
    {
        currentPoint = points[pointSelection];
        player = GameObject.FindGameObjectWithTag("Player");
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
        bulletTimer += Time.deltaTime;
        if (bulletTimer >= shootInterval)
        {
            GameObject bulletClone;
            bulletClone = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity) as GameObject;
            bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0);
            bulletTimer = 0;
         }
    }
    
    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        bullet.transform.localScale = new Vector2(bullet.transform.localScale.x * -1, bullet.transform.localScale.y);
        isLeft = !isLeft;
        bulletSpeed *= -1;
    }
}
