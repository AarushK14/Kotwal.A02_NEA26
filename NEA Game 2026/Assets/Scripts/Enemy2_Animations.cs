using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_Animations : MonoBehaviour {

	private Animator MyAnimator;
	public float enemySpeed;
	private Rigidbody2D enemy2;
	public GameObject leftMarker;
	public GameObject rightMarker;
	private Transform currentPoint;

	// Use this for initialization
	void Start () {
		MyAnimator = GetComponent<Animator> ();
		enemy2 = GetComponent<Rigidbody2D> ();
		currentPoint = rightMarker.transform;
		MyAnimator.SetBool ("walk", true);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 point = currentPoint.position - transform.position;
		if (currentPoint == rightMarker.transform) {
			enemy2.velocity = new Vector2 (enemySpeed, 0);
		} 
		else 
		{
			enemy2.velocity = new Vector2 (-enemySpeed, 0);
		}
		if (Vector2.Distance (transform.position, currentPoint.position) < 0.5f && currentPoint == rightMarker.transform) {
			currentPoint = leftMarker.transform;
		}
		if (Vector2.Distance (transform.position, currentPoint.position) < 0.5f && currentPoint == leftMarker.transform) {
			currentPoint = rightMarker.transform;
		}
	}
}
