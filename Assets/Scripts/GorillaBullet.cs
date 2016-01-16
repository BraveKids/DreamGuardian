using UnityEngine;
using System.Collections;

public class GorillaBullet : MonoBehaviour {
	Animator anim;
	void Start(){
		anim = GetComponent<Animator> ();
		Invoke ("DestroyBullet", 3f); 
	}
	
	
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.isTrigger != true)
		{
			anim.Play("destroy");
			Invoke ("DestroyBullet", 0.05f);
		}
	}
	
	void DestroyBullet(){
		Destroy(gameObject);
	}
}
