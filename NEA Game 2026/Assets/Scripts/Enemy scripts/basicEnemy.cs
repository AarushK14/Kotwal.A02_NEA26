using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Created: Sprint 3 - Last Edited: Sprint 6
// Purpose: Controlling the enemy, making sure they play the right animation and controlling which way they face based on users position

public class basicEnemy : MonoBehaviour {

	public GameObject player;
	Animator MyAnimator;
	public int enemyHealth;
	public int enemySpeed;
	string dir; // Holds the current movement direction
	Vector3 scaleLeft;
	Vector3 scaleRight;
	public GameObject coin; // Item to drop on death

	// Use this for initialization
	void Start () {
		enemySpeed = 6;
		dir = "left";

		// Set enemy size based on the level
		if (SceneManager.GetActiveScene ().name == "tutorial" || SceneManager.GetActiveScene ().name == "lvl 1") {
			scaleLeft = new Vector3 (17, 17, 1);
			scaleRight = new Vector3 (-17, 17, 1);
		} else {
			scaleLeft = new Vector3 (12, 12, 1);
			scaleRight = new Vector3 (-12, 12, 1);
		}

		MyAnimator = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");

		// Set health based on difficulty settings
		if (SceneManager.GetActiveScene ().name == "tutorial") {
			enemyHealth = 1;
		} else {
			enemyHealth	= 1 + PlayerPrefs.GetInt ("difficulty",0);
		}
	}

	// Update is called once per frame
	void Update () {
		// Moves the enemy left or right constantly
		if (dir == "left") {
			transform.Translate (-1 * Time.deltaTime * enemySpeed, 0, 0);
		}
		if (dir == "right") {
			transform.Translate (1 * Time.deltaTime * enemySpeed, 0, 0);
		}
	}

	void OnTriggerEnter2D(Collider2D collision){

		// Logic for getting hit by an arrow
		if (collision.tag == "arrow") {
			player.SendMessage ("arrowHitSound");
			Destroy (collision.gameObject);
			enemyHealth -= 1;

			if (enemyHealth == 0) {
				int x = Random.Range (1, 10); // Random chance to drop a coin
				Destroy (this.gameObject);
				if (x == 4 || x == 7) {
					Instantiate (coin, gameObject.transform.position , Quaternion.identity);
				}
			}

			// Update the score manager
			scoreController scoreManager = GameObject.FindGameObjectWithTag ("Player").GetComponent<scoreController> ();
			if (scoreManager != null) {
				scoreManager.basicEnemy();
			}
		}

		// Turn around if hitting a movement marker
		if (collision.tag == "leftMarker") {
			transform.localScale = scaleRight;
			dir = "right";
		}
		if (collision.tag == "rightMarker") {
			transform.localScale = scaleLeft;
			dir = "left";
		}

	}

	// Trigger attack animation if touching player
	void OnTriggerStay2D(Collider2D collision){
		if (collision.tag == "Player") {
			MyAnimator.SetTrigger ("attack");
			StartCoroutine (playHit ());
		}
	}

	// Go back to idle when player leaves
	private void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			MyAnimator.SetTrigger ("idle");
		}
	}

	// Small delay for attack timing
	IEnumerator playHit(){
		yield return new WaitForSeconds (2f);
	}
}
