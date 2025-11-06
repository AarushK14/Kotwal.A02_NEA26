using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Created: Sprint 3 - Last Edited: Sprint 4
// Purpose: Controlling the score counter and making changes to it based on what item the player collides with

public class Score : MonoBehaviour {

	public TextMeshPro ScoreCounter;
	public GameObject coin;
	int score;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (score);
		ScoreCounter.text = "Score: " + score.ToString ();
	}
	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "coin") {
			score += 2;
		}

	}
}
