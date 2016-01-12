using UnityEngine;
using System.Collections;

public class TankShield : MonoBehaviour {

    public TankAI tankAI;
    public float shieldInterval;
    float shieldTimer;
    bool azzera = false;

	// Use this for initialization
	void Start () {
        tankAI  = gameObject.GetComponentInParent<TankAI>();

    }
	
	// Update is called once per frame
	void Update () {
        if (azzera == true)
        {
            shieldTimer += Time.deltaTime;
            if (shieldTimer >= shieldInterval)
            {
                tankAI.shieldIsActive = false;
                azzera = false;
                shieldTimer = 0;
            }
        }
        

    }
    

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("AttackTrigger"))
        {
            tankAI.shieldIsActive = true;
            tankAI.anim.SetTrigger("shield");
            azzera = true;
            

        }
    
    }

}
