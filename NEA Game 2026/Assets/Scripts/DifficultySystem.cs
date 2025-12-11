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
		
		ArrowSpeed = 10f;

		if (SceneManager.GetActiveScene().name == "tutorial"){
			lives = 10f;
			enemyHealth = 1;
			PlayerSpeed = 10f;
			jumpForce = 380f;
			Orbspeed = 5f;
		}
		else if (SceneManager.GetActiveScene().name == "lvl 1"){
			lives = 7f;
			enemyHealth = 2;
			PlayerSpeed = 10f;
			jumpForce = 380f;
			Orbspeed = 7f;
		}
		else if (SceneManager.GetActiveScene().name == "lvl 2"){
			lives = 5f;
			enemyHealth = 3;
			PlayerSpeed = 10f;
			jumpForce = 380f;
			Orbspeed = 10f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
