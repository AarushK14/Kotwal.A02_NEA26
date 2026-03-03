using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour {

	Animator MyAnimator;

	// Use this for initialization
	void Start () {
		MyAnimator = GetComponent<Animator> ();
	}

	// plays the opening animation for the chest if collides with arrow
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "arrow") {
			MyAnimator.SetTrigger ("chestOpened");
		}
	}
}