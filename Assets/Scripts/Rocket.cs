using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

    public float speed;
    float lifeTime = 10f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        this.transform.position = this.transform.position - this.transform.right * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       Destroy(gameObject);
    }
    
}
