using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created: Sprint 1 - Last Edited: Sprint 1
// Purpose: To allow character move based on the key pressed and add playability to the game.

public class Movement : MonoBehaviour {

	Animator MyAnimator;

	// Use this for initialization
	void Start () {
		MyAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.D)) {
			MyAnimator.SetTrigger ("run");

		} else if (Input.GetKey (KeyCode.S)) {
			MyAnimator.SetTrigger ("roll");
		}

		else if (Input.GetKey (KeyCode.Space)) {
			MyAnimator.SetTrigger ("jump");

		} else if (MyAnimator.GetBool ("dead") == false) {
			MyAnimator.SetBool ("idle", true);
			MyAnimator.SetBool ("run", false);
		}
	}
}
