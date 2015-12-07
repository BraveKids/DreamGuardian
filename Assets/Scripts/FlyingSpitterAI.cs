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

    // Use this for initialization
    void Start()
    {
        currentPoint = points[pointSelection];
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
    }
    public void Attack()
    {
        bulletTimer += Time.deltaTime;
        if (bulletTimer >= shootInterval)
        {
            GameObject bulletClone;
            bulletClone = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity) as GameObject;
            bulletTimer = 0;
         }
    }
}
