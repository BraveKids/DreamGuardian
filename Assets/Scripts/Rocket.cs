using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

    public float speed;
    float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true)
        {
            Destroy(gameObject);
        }
       
    }
    
}
