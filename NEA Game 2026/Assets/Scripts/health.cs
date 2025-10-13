using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour {

	int lives = 5;
	GameObject player;
	GameObject enemy;
	Animator MyAnimator;

	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		
	}

	public void dmg(){
		lives -= 1;
		if (lives < 0) {
			MyAnimator.SetTrigger ("death");
		}
	}
}
