using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Created: Sprint 3 - Last Edited: Sprint 4
// Purpose: Controlling the enemy, making sure they play the right animation and controlling which way they face based on users position

public class enemy : MonoBehaviour {

	public GameObject player;
	Animator MyAnimator;
	public float enemyHealth;

	// Use this for initialization
	void Start () {
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
		if (player.transform.position.x > transform.position.x) {
			if (SceneManager.GetActiveScene ().name == "tutorial" || SceneManager.GetActiveScene ().name == "lvl 1") {
				transform.localScale = new Vector2 (-17f, 17f);
			} else {
				transform.localScale = new Vector2 (-12f, 12f);
			}
		} 
		if (SceneManager.GetActiveScene ().name == "tutorial" || SceneManager.GetActiveScene ().name == "lvl 1") {
			transform.localScale = new Vector2 (17f, 17f);
		} else {
			transform.localScale = new Vector2 (12f, 12f);
		}
	}

	void OnTriggerEnter2D(Collider2D collision){

		if (collision.tag == "arrow") {
			player.SendMessage ("arrowHitSound");
			Destroy (collision.gameObject);
			enemyHealth -= 1;
			if (enemyHealth == 0) {
				Destroy (this.gameObject);
			}
			Score scoreManager = GetComponent<Score> ();
			if (scoreManager != null) {
				scoreManager.basicEnemy ();
			}
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