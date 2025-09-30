using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

	private float arrowspeed;
	private Vector3 mousepos;

	// Use this for initialization
	void Start () {
		arrowspeed = 5f;
	}
	// Update is called once per frame
	void Update () {
		mousepos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = Vector3.MoveTowards (transform.position, mousepos, arrowspeed * Time.deltaTime);
	}
}