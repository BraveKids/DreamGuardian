using UnityEngine;
using System.Collections;

public class GorillaBullet : MonoBehaviour {
	public AudioSource shootSound;
	Animator anim;
	void Start(){
		shootSound.PlayOneShot (shootSound.clip);
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
