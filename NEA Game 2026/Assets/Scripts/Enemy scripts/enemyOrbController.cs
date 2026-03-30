using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Created: Sprint 6 - Last Edited: Sprint 6
// Purpose: used to control the instantiation of the enemy orb, controlling, and managing the health of the advanced enemy

public class enemyOrbController : MonoBehaviour {

	private Transform target;
	public float Orbspeed;
	GameObject player;
	public GameObject enemy2;

	// Use this for initialization
	void Start () {
		// Finds the player and the advanced enemy in the scene
		player = GameObject.FindGameObjectWithTag("Player");
		enemy2 = GameObject.FindGameObjectWithTag ("enemy2");

		// Sets orb travel speed based on current level or difficulty setting
		if (SceneManager.GetActiveScene ().name == "tutorial") {
			Orbspeed = 3f;
		} else {
			Orbspeed = PlayerPrefs.GetInt ("difficulty",0) * 5;
			Debug.Log (Orbspeed);
		}
	}

	// Update is called once per frame
	void Update () {
		// Targets the player and moves the orb toward them every frame
		target = player.transform;
		float distance = Orbspeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, distance);

		// Automatically cleans up the orb after 4 seconds
		Destroy (this.gameObject, 4f);
	}

	// Handles what happens when the orb touches something
	void OnTriggerEnter2D(Collider2D other){
		// If it hits the player, the orb disappears
		if (other.tag == "Player"){
			Destroy (this.gameObject);
		}
		// If it hits an arrow, destroy both and tell the parent enemy to lose health
		else if (other.gameObject.tag == "arrow") {
			Destroy (other.gameObject);
			Destroy (this.gameObject);
			GetComponentInParent<advancedEnemyController>().SendMessage ("LoseLife");
		}
	}
}