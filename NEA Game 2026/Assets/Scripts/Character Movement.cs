using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created: Sprint 1 - Last Edited: Sprint 1
// Purpose: To allow character move based on the key pressed and add playability to the game.

public class CharacterMvement : MonoBehaviour {

	Animator MyAnimator;

	// Use this for initialization
	void Start () {
		MyAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.D)) {
			MyAnimator.SetBool ("run", true);
			MyAnimator.Play("run");
		} else if (Input.GetKey (KeyCode.S)) {
			MyAnimator.SetBool ("roll", true);
		} else if (Input.GetKey (KeyCode.W)) {
			MyAnimator.SetBool ("attack", true);
		} else if (Input.GetKey (KeyCode.Space)) {
			MyAnimator.Play ("jump");
		} else if (MyAnimator.GetBool ("dead") == false) {
			MyAnimator.SetBool ("idle", true);
			MyAnimator.SetBool ("run", false);
		}
	}
}
