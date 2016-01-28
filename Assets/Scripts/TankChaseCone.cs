using UnityEngine;
using System.Collections;

public class TankChaseCone : MonoBehaviour {

    public TankAI tankAI;

	// Use this for initialization
	void Start () {
        tankAI = gameObject.GetComponentInParent<TankAI>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            tankAI.inseguimento = true;
            tankAI.ritorno = false;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            tankAI.inseguimento = false;
            tankAI.ritorno = true;
        }
    }
}
