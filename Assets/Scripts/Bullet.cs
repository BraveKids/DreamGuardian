using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void Start(){
		Invoke ("DestroyBullet", 3f); 
	}


	void OnTriggerEnter2D (Collider2D col)
    {
        if (col.isTrigger != true)
        {
            Destroy(gameObject);
        }
    }

	void DestroyBullet(){
		Destroy(gameObject);
	}
}
