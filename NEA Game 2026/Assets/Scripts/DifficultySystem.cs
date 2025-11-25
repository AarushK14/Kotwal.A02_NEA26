using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySystem : MonoBehaviour {

	public float PlayerSpeed;
	float lives;
	float enemyHealth;
	float jumpForce;

	// Use this for initialization
	void Start (){
	
	}
	
	// Update is called once per frame
	/*void Update () {
		if ((SceneManager.GetActiveScene()) == "tutorial"){
			lives = 10f;
			enemyHealth = 1f;
			PlayerSpeed = 10f;
		}
	}*/
}
