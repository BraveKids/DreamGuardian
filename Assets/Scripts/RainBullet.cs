using UnityEngine;
using System.Collections;

public class RainBullet : MonoBehaviour {

    float lifeTime = 10f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
    }

}
