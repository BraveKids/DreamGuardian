using UnityEngine;
using System.Collections;

public class movingWallScript : MonoBehaviour {
	public GameObject condition1, condition2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (condition1.gameObject.activeSelf == false && condition2.gameObject.activeSelf == false) {
			this.gameObject.SetActive(false);
		}
	}
}
