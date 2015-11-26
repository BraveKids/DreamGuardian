using UnityEngine;
using System.Collections;

public class movingWallScript : MonoBehaviour {
	public GameObject condition1, condition2;
	public Transform movePoint;
	public float moveSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (condition1.gameObject.activeSelf == false && condition2.gameObject.activeSelf == false) {
			transform.position = Vector3.MoveTowards (transform.position, movePoint.position,Time.deltaTime*moveSpeed);
		}
	}
}
