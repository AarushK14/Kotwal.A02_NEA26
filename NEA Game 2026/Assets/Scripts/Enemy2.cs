using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy2 : MonoBehaviour {

	private Animator MyAnimator;
	public float enemySpeed;
	private Rigidbody2D enemy2;
	private string dir;
	Vector3 scaleLeft;
	Vector3 scaleRight;
	private DifficultySystem VariableRef;
	public int health;
	public GameObject orb;

	// Use this for initialization
	void Start () {
		enemySpeed = 6;
		MyAnimator = GetComponent<Animator> ();
		MyAnimator.SetBool ("walk", true);
		dir = "left";
		scaleLeft = new Vector3 (13, 13, 1);
		scaleRight = new Vector3 (-13, 13, 1);
		if (SceneManager.GetActiveScene ().name == "tutorial") {
			health = 5;
		} else {
			health = 5 + PlayerPrefs.GetInt ("difficulty");
		}
	}
	// Update is called once per frame
	void Update () {
		if (dir == "left") {
			transform.Translate (-1 * Time.deltaTime * enemySpeed, 0, 0);
		}
		if (dir == "right") {
			transform.Translate (1 * Time.deltaTime * enemySpeed, 0, 0);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "leftMarker") {
			transform.localScale = scaleRight;
			transform.Translate(1* Time.deltaTime * enemySpeed, 0, 0);
			dir = "right";
		}
		if (other.gameObject.tag == "rightMarker") {
			transform.localScale = scaleLeft;
			transform.Translate(-1* Time.deltaTime * enemySpeed, 0, 0);
			dir = "left";
		}
		if (other.gameObject.tag == "Player") {
			Debug.Log ("detected!");
			SpawnOrb (this.transform);
			if (SceneManager.GetActiveScene ().name == "tutorial") {	
				GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().instructions.text = "you're under attack! shoot the orb to kill the ranged enemy";
			}

			if (health == 0) {
				Destroy (other.gameObject);
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
			MyAnimator.SetBool ("death", true);
			Destroy (this.gameObject);
		}
	}

	public void SpawnOrb(Transform pos){
		Instantiate (orb,pos.position,Quaternion.identity,this.gameObject.transform);
		MyAnimator.SetBool ("attack", true);
	}
}
