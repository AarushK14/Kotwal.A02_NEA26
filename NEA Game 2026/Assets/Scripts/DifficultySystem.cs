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
		PlayerSpeed = 10;
		jumpForce = 380f;

		if (SceneManager.GetActiveScene ().name == "tutorial") {
			lives = 10f;
			enemyHealth = 1;
			Orbspeed = 3;
		} else {
			lives = 11 - 2 * PlayerPrefs.GetInt ("difficulty");
			enemyHealth = 1 + PlayerPrefs.GetInt ("difficulty");
			Orbspeed = PlayerPrefs.GetInt ("difficulty") * 5;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
