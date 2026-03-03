using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playerHealthController : MonoBehaviour {

	int lives = 5; // Starting number of lives
	GameObject player;
	GameObject enemy;
	public Animator MyAnimator;

	// Use this for initialization
	void Start () {
		// Prints current lives to the console at the start
		Debug.Log (lives);
	}

	// This function handles taking damage
	public void dmg(){
		lives -= 1; // Take away one life

		// If lives run out, play death animation and load the Game Over scene
		if (lives < 0) {
			MyAnimator.SetTrigger ("death");
			SceneManager.LoadScene ("Lost");
		}
	}
}