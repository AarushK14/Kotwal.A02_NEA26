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
	public int enemy2health;

	// Use this for initialization
	void Start (){
		
		ArrowSpeed = 10f;

		if (SceneManager.GetActiveScene().name == "tutorial"){
			lives = 10f;
			enemyHealth = 1;
			PlayerSpeed = 10;
			jumpForce = 380f;
			Orbspeed = 3;
			enemy2health = 3;
		}
		else{
			lives = 11- 2*PlayerPrefs.GetInt("difficulty");
			enemyHealth = 1+PlayerPrefs.GetInt("difficulty");
			PlayerSpeed = 10f;
			jumpForce = 380f;
			Orbspeed = PlayerPrefs.GetInt("difficulty")*5;
			enemy2health = 5 + PlayerPrefs.GetInt ("difficulty");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
