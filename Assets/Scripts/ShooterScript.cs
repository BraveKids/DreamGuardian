using UnityEngine;
using System.Collections;

public class ShooterScript : MonoBehaviour {

		public float shootInterval;
		public float bulletSpeed = 100;
		public float bulletTimer;
		public bool awake = false;
		public bool lookingRight = true;
		public GameObject bullet;

		public Transform shootPoint;

		
		void Awake()
		{
	
		}
		
		// Use this for initialization
		void Start (){
			
		}
		
		// Update is called once per frame
		void Update () {
			Attack ();
			
		}

		
		public void Attack ()
		{
			bulletTimer += Time.deltaTime;
			if (bulletTimer >= shootInterval) {	
			Vector2 direction = shootPoint.transform.position - transform.position;
			direction.Normalize ();
			GameObject bulletClone;
			bulletClone = Instantiate (bullet, shootPoint.transform.position, shootPoint.transform.rotation)as GameObject;
			bulletClone.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;
			bulletTimer = 0;
		}

			}
		}
	