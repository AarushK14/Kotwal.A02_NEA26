using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class health : MonoBehaviour {

	int lives = 5;
	GameObject player;
	GameObject enemy;
	public Animator MyAnimator;

	// Use this for initialization
	void Start () {
		Debug.Log (lives);
	}
	// Update is called once per frame
	void Update () {
		
	}

	public void dmg(){
		lives -= 1;
		if (lives < 0) {
			MyAnimator.SetTrigger ("death");
			SceneManager.LoadScene ("Lost");
		}
	}
}
