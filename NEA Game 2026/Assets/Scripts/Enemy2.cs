using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy2 : MonoBehaviour {

	private Animator MyAnimator;
	public float enemySpeed;
	private Rigidbody2D enemy2;
	public int health;
	public GameObject orb;

	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene ().name == "tutorial") {
			health = 5;
		} else {
			health = 5 + PlayerPrefs.GetInt ("difficulty");
		}
	}
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			Debug.Log ("detected!");
			SpawnOrb (this.transform);
			if (SceneManager.GetActiveScene ().name == "tutorial") {	
				GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().instructions.text = "you're under attack! shoot the orb to kill the ranged enemy";
			}

			if (health == 0) {
				Destroy (this.gameObject);
			}
		}

	}

	public void LoseLife(){
		health = health - 1;
		Debug.Log (health);
		Score scoreManager = GameObject.FindGameObjectWithTag ("Player").GetComponent<Score> ();
		if (scoreManager != null) {
			scoreManager.advancedEnemy();
		}
		if (health == 0) {
			//MyAnimator.SetBool ("death", true);
			Destroy (this.gameObject);
		}
	}

	public void SpawnOrb(Transform pos){
		Instantiate (orb, pos.position, Quaternion.identity,this.gameObject.transform);
		GameObject parent = this.gameObject;
		//MyAnimator.SetBool ("attack", true);
	}
}
