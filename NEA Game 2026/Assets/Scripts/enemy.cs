using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Created: Sprint 3 - Last Edited: Sprint 6
// Purpose: Controlling the enemy, making sure they play the right animation and controlling which way they face based on users position

public class enemy : MonoBehaviour {

	public GameObject player;
	Animator MyAnimator;
	public float enemyHealth;
	public float enemySpeed;
	string dir;
	Vector3 scaleLeft;
	Vector3 scaleRight;

	// Use this for initialization
	void Start () {
		enemySpeed = 6;
		dir = "left";
		if (SceneManager.GetActiveScene ().name == "tutorial" || SceneManager.GetActiveScene ().name == "lvl 1") {
			scaleLeft = new Vector3 (17, 17, 1);
			scaleRight = new Vector3 (-17, 17, 1);
		} else {
			scaleLeft = new Vector3 (12, 12, 1);
			scaleRight = new Vector3 (-12, 12, 1);
		}
		MyAnimator = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		if (SceneManager.GetActiveScene ().name == "tutorial") {
			enemyHealth = 1f;
			Debug.Log (enemyHealth);
		} else {
			enemyHealth	= 1f + PlayerPrefs.GetInt ("difficulty",0);
			Debug.Log (enemyHealth);
		}
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

	void OnTriggerEnter2D(Collider2D collision){

		if (collision.tag == "arrow") {
			player.SendMessage ("arrowHitSound");
			Destroy (collision.gameObject);
			enemyHealth -= 1;
			if (enemyHealth == 0) {
				Destroy (this.gameObject);
				player.SendMessage ("W");
			}
			Score scoreManager = GameObject.FindGameObjectWithTag ("Player").GetComponent<Score> ();
			if (scoreManager != null) {
				scoreManager.basicEnemy();
			}
		}

		if (collision.tag == "leftMarker") {
			transform.localScale = scaleRight;
			transform.Translate(1* Time.deltaTime * enemySpeed, 0, 0);
			dir = "right";
		}
		if (collision.tag == "rightMarker") {
			transform.localScale = scaleLeft;
			transform.Translate(-1* Time.deltaTime * enemySpeed, 0, 0);
			dir = "left";
		}

	}

	void OnTriggerStay2D(Collider2D collision){
		if (collision.tag == "Player") {
			MyAnimator.SetTrigger ("attack");
			StartCoroutine (playHit ());
		}

	}

	private void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			Debug.Log ("this works!");
			MyAnimator.SetTrigger ("idle");
			Debug.Log ("this works too!");
		}
	}

	IEnumerator playHit(){
		yield return new WaitForSeconds (2f);
	}
}

// ideas: get the health for enemy, add a smiliar sytem to the player one for health and health bar.