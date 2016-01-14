using UnityEngine;
using System.Collections;

public class ZombieDamage : MonoBehaviour {
    Animator anim;
    public float hp = 4;
    private PlayerAttack playerScript;
    GameObject player;
    public GameObject enemy;
    // Use this for initialization
    void Start()
    {
        anim = GetComponentInParent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.gameObject.GetComponent("PlayerAttack") as PlayerAttack;
        
    }

   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AttackTrigger"))
        {
            hp -= 1;
            anim.SetTrigger("damage");
            Debug.Log("OUCH! " + hp + " left!");
            if (hp <= 0)
            {
                anim.Play("explosion");
                Invoke("DestroyEnemy", 0.15f);


            }
        }
        if (other.CompareTag("SuperAttackTrigger"))
        {
            anim.SetTrigger("explode");
            DestroyEnemy();
        }
    }


    void DestroyEnemy()
    {
        enemy.gameObject.SetActive(false);
        if (playerScript.energy < 3)
        {
            playerScript.energy += 1;
        }

    }

   
}
