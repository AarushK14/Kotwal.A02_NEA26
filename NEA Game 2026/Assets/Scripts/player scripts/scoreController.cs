using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// Created: Sprint 3 - Last Edited: Sprint 4
// Purpose: Controlling the score counter and making changes to it based on what item the player collides with

public class scoreController : MonoBehaviour {

	public TextMeshProUGUI ScoreCounter; // UI text display for the score
	public GameObject coin;
	public static int score; // Static so the score stays the same across levels

	// Update is called once per frame
	void Update () {
		// Updates the UI text with the current score
		ScoreCounter.text = "Score: " + score.ToString ();
		// Saves the score to PlayerPrefs so the leaderboard can use it
		PlayerPrefs.SetInt ("userScore", score);
	}

	// Adds points when hitting a coin trigger
	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "coin") {
			score += 10;
		}
	}

	// Award points for killing a basic enemy
	public void basicEnemy(){
		score += 7;
	}

	// Award points for killing an advanced enemy
	public void advancedEnemy(){
		score += 3;
	}

	// Award points for picking up buffs or debuffs
	public void buffsDebuffs(){
		score += 5;
	}

	// Resets the score to zero (used when restarting)
	public void resetScore(){
		score = 0;
	}
}