using UnityEngine;
using System.Collections;

public class ZombieDamage : MonoBehaviour {
    Animator anim;
    public float hp = 4;
	public float deathTimer = 0.2f;
    private CharacterControllerScript playerScript;
    GameObject player;
	SpriteRenderer renderer;
	AudioSource audio;
	Color normalColor;
    public GameObject enemy;
    public bool allowAction = true;
    // Use this for initialization
    void Start()
    {
		audio = GetComponent<AudioSource> ();
		renderer = GetComponentInParent<SpriteRenderer> ();
		normalColor = renderer.material.color;
        anim = GetComponentInParent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.gameObject.GetComponent("CharacterControllerScript") as CharacterControllerScript;
        
    }
	IEnumerator DamageCoroutine () {
		Debug.Log ("Flash");
		renderer.material.color = Color.red;
		yield return new WaitForSeconds (0.1f);
		renderer.material.color = normalColor;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AttackTrigger") && hp>0)
        {
			StartCoroutine ("DamageCoroutine");
			audio.PlayOneShot(audio.clip);
            hp -= 1;
            anim.Play("damage");
			if (hp <= 0) {
				anim.Play ("explosion");
                if (playerScript.energy < 10)
				{
                        playerScript.energy += 1;
                        GameObject.Find("HUD").GetComponent<HUDManager>().updateMP(playerScript.energy);
                    }
                allowAction = false;
				Invoke ("DestroyEnemy", deathTimer);
				
				
			}
          
        }
 
    }


    void DestroyEnemy()
    {
        enemy.gameObject.SetActive(false);
      

    }

   
}
