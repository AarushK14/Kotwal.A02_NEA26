using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Created: Sprint 1 - Last Edited: Sprint 2
// Purpose: To allow character move based on the key pressed and add playability to the game.

public class CharacterMovement : MonoBehaviour {

	Animator MyAnimator;

	// Use this for initialization
	void Start () {
		MyAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.A)) {
			MyAnimator.SetTrigger ("run");
			transform.rotation = Quaternion.Euler (0f, 180f, 0f);

		} else if (Input.GetKeyDown (KeyCode.D)) {
			MyAnimator.SetTrigger ("run");
			transform.rotation = Quaternion.Euler (0f, 0f, 0f);
		} else if (Input.GetKey (KeyCode.Space)) {
			MyAnimator.SetTrigger ("jump");

		} else if (Input.GetAxis ("Horizontal") == 0) {
			MyAnimator.SetTrigger ("idle");
		} 
		else if (Input.GetKey (KeyCode.Escape)) {
			SceneManager.LoadScene ("pause");
		}
	}
}
