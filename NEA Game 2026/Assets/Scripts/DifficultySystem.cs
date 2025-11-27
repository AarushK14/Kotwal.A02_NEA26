using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySystem : MonoBehaviour {

	public float PlayerSpeed;
	public float lives;
	public float enemyHealth;
	public float jumpForce;

	// Use this for initialization
	void Start (){
		if (SceneManager.GetActiveScene().name == "tutorial"){
			lives = 10f;
			enemyHealth = 1;
			PlayerSpeed = 10f;
			jumpForce = 380f;
		}
		else if (SceneManager.GetActiveScene().name == "lvl 1"){
			lives = 7f;
			enemyHealth = 2;
			PlayerSpeed = 10f;
			jumpForce = 380f;
		}
		else if (SceneManager.GetActiveScene().name == "lvl 2"){
			lives = 5f;
			enemyHealth = 3;
			PlayerSpeed = 10f;
			jumpForce = 380f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
