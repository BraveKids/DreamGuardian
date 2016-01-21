using UnityEngine;
using System.Collections;

public class KnightBossTrigger : MonoBehaviour {

		public GameObject KnightBoss;
		private KnightBossScript knightScript;
		// Use this for initialization
		void Start () {
			knightScript = KnightBoss.gameObject.GetComponent("KnightBossScript") as KnightBossScript;
			
		}
		
		// Update is called once per frame
		void OnTriggerEnter2D(Collider2D other){
			if(other.CompareTag("Player")){
				knightScript.active = true;
				//knightScript.anim.SetBool("attack", true);
				this.gameObject.SetActive(false);
			}
		}
	}
