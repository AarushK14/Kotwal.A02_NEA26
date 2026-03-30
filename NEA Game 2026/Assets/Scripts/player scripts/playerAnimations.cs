using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Created: Sprint 1 - Last Edited: Sprint 4
// Purpose: To allow character move based on the key pressed and add playability to the game.

public class playerAnimations : MonoBehaviour {

	Animator MyAnimator;

	// Use this for initialization
	void Start () {
		// Get the animator component from the player object
		MyAnimator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		// Check if moving left
		if (Input.GetKeyDown (KeyCode.A)) {
			MyAnimator.SetTrigger ("run");
			// Rotate the player to face left
			transform.rotation = Quaternion.Euler (0f, 180f, 0f);

			// Check if moving right
		} else if (Input.GetKeyDown (KeyCode.D)) {
			MyAnimator.SetTrigger ("run");
			// Rotate the player to face right
			transform.rotation = Quaternion.Euler (0f, 0f, 0f);

			// Check for jump input
		} else if (Input.GetKeyDown (KeyCode.W)) {
			MyAnimator.SetTrigger ("jump");

			// If no movement keys are pressed, go back to idle
		} else if (Input.GetAxis ("Horizontal") == 0) {
			MyAnimator.SetTrigger ("idle");
		}
	}
}