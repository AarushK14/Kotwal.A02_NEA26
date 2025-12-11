using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour {

	public float speed;
	private string dir;
	Vector3 scaleLeft;
	Vector3 scaleRight;

	// Use this for initialization
	void Start () {
		speed = 6;
		dir = "left";
		scaleLeft = new Vector3 (3.33f, 1.67f, 1);
		scaleRight = new Vector3 (-3.33f, 1.67f, 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (dir == "left") {
			transform.Translate (-1 * Time.deltaTime * speed, 0, 0);
		}
		if (dir == "right") {
			transform.Translate (1 * Time.deltaTime * speed, 0, 0);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "leftMarker") {
			transform.localScale = scaleRight;
			transform.Translate(1* Time.deltaTime * speed, 0, 0);
			dir = "right";
		}
		if (other.gameObject.tag == "rightMarker") {
			transform.localScale = scaleLeft;
			transform.Translate(-1* Time.deltaTime * speed, 0, 0);
			dir = "left";
		}
	}
}
