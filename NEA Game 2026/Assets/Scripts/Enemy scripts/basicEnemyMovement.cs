using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemyMovement : MonoBehaviour {

	public float speed;
	private string dir; // Tracks if moving "left" or "right"
	Vector3 scaleLeft;
	Vector3 scaleRight;

	// Use this for initialization
	void Start () {
		speed = 6;
		dir = "left";
		// Pre-set the scale values for flipping the sprite
		scaleLeft = new Vector3 (3.33f, 1.67f, 1);
		scaleRight = new Vector3 (-3.33f, 1.67f, 1);
	}

	// Update is called once per frame
	void Update () {
		// Moves the enemy left or right based on the current 'dir' string
		if (dir == "left") {
			transform.Translate (-1 * Time.deltaTime * speed, 0, 0);
		}
		if (dir == "right") {
			transform.Translate (1 * Time.deltaTime * speed, 0, 0);
		}
	}

	// Detects when the enemy hits a patrol marker
	void OnTriggerEnter2D(Collider2D other){
		// If hits the left boundary, flip scale and head right
		if (other.gameObject.tag == "leftMarker") {
			transform.localScale = scaleRight;
			transform.Translate(1* Time.deltaTime * speed, 0, 0);
			dir = "right";
		}
		// If hits the right boundary, flip scale and head left
		if (other.gameObject.tag == "rightMarker") {
			transform.localScale = scaleLeft;
			transform.Translate(-1* Time.deltaTime * speed, 0, 0);
			dir = "left";
		}
	}
}
