using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Created: Sprint 6 - Last Edited: Sprint 6
// Purpose: to make and control advanced enemies and make them spawn orbs which follow the player.

public class advancedEnemyController : MonoBehaviour {

	private Rigidbody2D enemy2;
	public int health;
	public GameObject orb; // The orb the enemy shoots
	public GameObject player;
	bool inContact; // Checks if player is close
	string objectName;

	// Use this for initialization
	void Start () {
		// Sets health based on difficulty level
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
		// This makes the enemy flip to face the player
		if (player.transform.position.x < transform.position.x) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
		} else {
			transform.rotation = Quaternion.Euler (0, 180, 0);
		}

		// If player is nearby, start the attack logic
		if (inContact == true) {
			Detectable ();
		}
	}

	public void Detectable(){
		if (inContact == true) {
			if (objectName == "Player") {
				Debug.Log ("detected!");
				// Shows tutorial text if in tutorial scene
				if (SceneManager.GetActiveScene ().name == "tutorial") {    
					GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().instructions.text = "you're under attack! shoot the orb to kill the ranged enemy";
				}
				// Shoots an orb
				StartCoroutine (orbControl ());

				if (health == 0) {
					Destroy (this.gameObject);
				}
			}
		}
	}

	// Detects when something enters the trigger zone
	void OnTriggerStay2D(Collider2D other){
		inContact = true;
		objectName = other.gameObject.tag;
	}

	// Detects when the player leaves the zone
	void OnTriggerExit2D(){
		inContact = false;
	}

	// Called when enemy gets hit
	public void LoseLife(){
		health = health - 1;
		Debug.Log (health);

		// Updates the score
		scoreController scoreManager = GameObject.FindGameObjectWithTag ("Player").GetComponent<scoreController> ();
		if (scoreManager != null) {
			scoreManager.advancedEnemy();
		}

		// Kill enemy if health is gone
		if (health <= 0) {
			Destroy (this.gameObject);
		}
	}

	// Spawns the orb at the enemy position
	public void SpawnOrb(Transform pos){
		Instantiate (orb, pos.position, Quaternion.identity,this.gameObject.transform);
	}

	// Wait time between shooting orbs
	public IEnumerator orbControl(){
		SpawnOrb (this.transform);
		yield return new WaitForSeconds (2f);
	}
}