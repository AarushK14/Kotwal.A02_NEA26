using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySystem : MonoBehaviour {

	public float PlayerSpeed;
	public float lives;
	public float enemyHealth;
	public float jumpForce;
	public float ArrowSpeed;
	public float Orbspeed;

	// Use this for initialization
	void Start (){
		// Set default values for player movement and attacks
		ArrowSpeed = 10f;
		PlayerSpeed = 10;
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