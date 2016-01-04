using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void Start(){
		Invoke ("DestroyBullet", 2f); 
	}


	void OnTriggerEnter2D (Collider2D col)
    {
        if (col.isTrigger != true)
        {
            if (col.CompareTag("Player"))
            {
                //col.GetComponent<Player>().Damage(1);
            }
            Destroy(gameObject);
        }
    }

	void DestroyBullet(){
		Destroy(gameObject);
	}
}
