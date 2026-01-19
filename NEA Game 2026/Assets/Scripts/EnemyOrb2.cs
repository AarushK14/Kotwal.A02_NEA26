using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Created: Sprint 6 - Last Edited: Sprint 6
// Purpose: Used to control the orb instantiated by the advanced enemies and make the advanced enemey lose health

public class EnemyOrb2 : MonoBehaviour {

	private Transform target;
	public float Orbspeed;
	GameObject player;
	public GameObject enemy2;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		enemy2 = GameObject.FindGameObjectWithTag ("enemy2");
		if (SceneManager.GetActiveScene ().name == "tutorial") {
			Orbspeed = 3f;
		} else {
			Orbspeed = PlayerPrefs.GetInt ("difficulty",0) * 5;
			Debug.Log (Orbspeed);
		}
	}

	// Update is called once per frame
	void Update () {
		target = player.transform;
		float distance = Orbspeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, distance);
		Destroy (this.gameObject, 4f);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player"){
			Destroy (this.gameObject);
		}
		else if (other.gameObject.tag == "arrow") {
			Debug.Log ("Sucess");
			Destroy (other.gameObject);
			Destroy (this.gameObject);
			GetComponentInParent<Enemy2>().SendMessage ("LoseLife");
		}
	}
}