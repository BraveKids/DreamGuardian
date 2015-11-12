using UnityEngine;
using System.Collections;

public class EndLevelScript : MonoBehaviour {
    public Transform destination;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //var startPosition = other.transform.position;
            other.transform.position = destination.position;
            //var moveDelta = other.transform.position - startPosition;
            //Camera.current.transform.position += moveDelta;
        }
        
    }
}
