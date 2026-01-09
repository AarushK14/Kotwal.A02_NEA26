using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Created: Sprint 3 - Last Edited: Sprint 4
// Purpose: Controlling the score counter and making changes to it based on what item the player collides with

public class Score : MonoBehaviour {

	public TextMeshProUGUI ScoreCounter;
	public GameObject coin;
	public static int score;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		ScoreCounter.text = "Score: " + score.ToString ();
		PlayerPrefs.SetInt ("userScore",score);
	}
	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "coin") {
			score += 10;
		}
	}

	public void basicEnemy(){
		score += 7;
	}

	public void advancedEnemy(){
		score += 3;
	}

	public void buffsDebuffs(){
		score += 5;
	}

	public void resetScore(){
		score = 0;
	}
}
