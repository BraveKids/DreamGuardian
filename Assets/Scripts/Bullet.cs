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
            Invoke("DestroyBullet", 0.1f);
        }
    }

	void DestroyBullet(){
		Destroy(gameObject);
	}
}
