using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Created: Sprint  - Last Edited: Sprint 
// Purpose: used to set the values of variable based on the opted difficulty.

public class DifficultySystem : MonoBehaviour {

	public float lives;
	public float jumpForce;

	// Use this for initialization
	void Start (){
		// Set default values for player movement and attacks
		jumpForce = 380f;

		// Check if current level is the tutorial to set specific life count
		if (SceneManager.GetActiveScene ().name == "tutorial") {
			lives = 10f;
		} else {
			// Calculate lives based on the difficulty setting saved in PlayerPrefs
			lives = 11 - (2 * PlayerPrefs.GetInt ("difficulty",0));
		}
	}
}