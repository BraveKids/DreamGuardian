using UnityEngine;
using System.Collections;

public class RainSpitterAI : MonoBehaviour {

    
    public GameObject cannonball;  
    float bulletTimer;
    public float shootInterval;
    public Transform shootPoint;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bulletTimer += Time.deltaTime;
        if (bulletTimer >= shootInterval)
        {
            GameObject ball;
            ball = Instantiate(cannonball, shootPoint.transform.position, Quaternion.identity) as GameObject;
            bulletTimer = 0;
        }

    }
}
