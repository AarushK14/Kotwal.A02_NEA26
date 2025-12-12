using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour {

	private Animator MyAnimator;
	public float enemySpeed;
	private Rigidbody2D enemy2;
	private string dir;
	Vector3 scaleLeft;
	Vector3 scaleRight;
	public int enemyhealth;

	// Use this for initialization
	void Start () {
		enemySpeed = 6;
		MyAnimator = GetComponent<Animator> ();
		MyAnimator.SetBool ("walk", true);
		dir = "left";
		scaleLeft = new Vector3 (13, 13, 1);
		scaleRight = new Vector3 (-13, 13, 1);
		enemyhealth = GetComponent<DifficultySystem> ().enemy2health;
	}
	// Update is called once per frame
	void Update () {
		if (dir == "left") {
			transform.Translate (-1 * Time.deltaTime * enemySpeed, 0, 0);
		}
		if (dir == "right") {
			transform.Translate (1 * Time.deltaTime * enemySpeed, 0, 0);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "leftMarker") {
			transform.localScale = scaleRight;
			transform.Translate(1* Time.deltaTime * enemySpeed, 0, 0);
			dir = "right";
		}
		if (other.gameObject.tag == "rightMarker") {
			transform.localScale = scaleLeft;
			transform.Translate(-1* Time.deltaTime * enemySpeed, 0, 0);
			dir = "left";
		}
	}

	void LoseLife(){
		enemyhealth = enemyhealth - 1;
		Debug.Log (enemyhealth);
		if (enemyhealth < 0) {
			Destroy (this.gameObject);
		}
	}
}
