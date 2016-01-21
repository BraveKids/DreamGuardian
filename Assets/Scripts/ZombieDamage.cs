using UnityEngine;
using System.Collections;

public class ZombieDamage : MonoBehaviour {
    Animator anim;
    public float hp = 4;
	public float deathTimer = 0.2f;
    private CharacterControllerScript playerScript;
    GameObject player;
    public GameObject enemy;
    // Use this for initialization
    void Start()
    {
        anim = GetComponentInParent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.gameObject.GetComponent("CharacterControllerScript") as CharacterControllerScript;
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AttackTrigger") && hp>0)
        {
            hp -= 1;
            anim.Play("damage");
			if (hp <= 0) {
				anim.SetTrigger("explosion");
				if (playerScript.energy < 10)
				{
					playerScript.energy += 1;
					GameObject.Find("HUD").GetComponent<HUDManager>().updateMP(playerScript.energy);
				}
				Invoke ("DestroyEnemy", deathTimer);
				
				
			}
          
        }
 
    }


    void DestroyEnemy()
    {
        enemy.gameObject.SetActive(false);
      

    }

   
}
