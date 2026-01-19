using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Created: Sprint 6 - Last Edited: Sprint 6
// Purpose: to make and control advanced enemies and make them spawn orbs which follow the player.

public class Enemy2 : MonoBehaviour {

	private Animator MyAnimator;
	public float enemySpeed;
	private Rigidbody2D enemy2;
	public int health;
	public GameObject orb;
	public GameObject player;
	bool inContact;
	string objectName;

	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene ().name == "tutorial") {
			health = 20;
		} else {
			health = 20 + 4*PlayerPrefs.GetInt ("difficulty");
		}
		player = GameObject.FindGameObjectWithTag ("Player");
		inContact = false;
	}
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x < transform.position.x) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
		} else {
			transform.rotation = Quaternion.Euler (0, 180, 0);
		}


		if (inContact == true) {
			Detectable ();
		}
	}

	public void Detectable(){
		if (inContact == true) {
			if (objectName == "Player") {
				Debug.Log ("detected!");
				if (SceneManager.GetActiveScene ().name == "tutorial") {	
					GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().instructions.text = "you're under attack! shoot the orb to kill the ranged enemy";
				}
				StartCoroutine (coolDown ());
				if (health == 0) {
					Destroy (this.gameObject);
				}
			}
		}
	}

	void OnTriggerStay2D(Collider2D other){
		inContact = true;
		objectName = other.gameObject.tag;
	}

	void OnTriggerExit2D(){
		inContact = false;
	}

	public void LoseLife(){
		health = health - 1;
		Debug.Log (health);
		Score scoreManager = GameObject.FindGameObjectWithTag ("Player").GetComponent<Score> ();
		if (scoreManager != null) {
			scoreManager.advancedEnemy();
		}
		if (health == 0) {
			Destroy (this.gameObject);
		}
	}

	public void SpawnOrb(Transform pos){
		Instantiate (orb, pos.position, Quaternion.identity,this.gameObject.transform);
		GameObject parent = this.gameObject;
	}

	public IEnumerator coolDown(){
		SpawnOrb (this.transform);
		yield return new WaitForSeconds (2f);
	}
}
