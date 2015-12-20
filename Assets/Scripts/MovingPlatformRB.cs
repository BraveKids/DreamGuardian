using UnityEngine;
using System.Collections;

public class MovingPlatformRB : MonoBehaviour {
	public GameObject platform;
	public float moveSpeed;
	public Transform currentPoint;
	public Transform[] points;
	public int pointSelection;
	Rigidbody2D rb;
	
	// Use this for initialization
	void Start () {
		currentPoint = points [pointSelection];
		rb = GetComponentInChildren<Rigidbody2D> ();
	}
	
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.MovePosition (Vector3.MoveTowards (platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed));
		if (platform.transform.position == currentPoint.position) {
			pointSelection++;
			
			if (pointSelection == points.Length) {
				pointSelection = 0;
			}
			
			currentPoint = points [pointSelection];
		}
		
	}
}