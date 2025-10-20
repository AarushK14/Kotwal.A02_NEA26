using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

// Created: Sprint 1 - Last Edited: Sprint 2
// Purpose: To allow character move based on the key pressed and add playability to the game.

public class control : MonoBehaviour {

	public float speed = 5f;
	public float jumpspeed = 5f;
	private float direction = 0f;
	private Rigidbody2D player;
	public bool on_ground;
	float lives = 10;
	Animator MyAnimator;
	private bool candie;
	public TextMeshPro livescounter;
	private float lives_Percentage;
	private float defaultlives;
	public Image HealthBar;
	public GameObject enemy;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D> ();
		MyAnimator = GetComponent<Animator> ();
		on_ground = true;
		candie = false;
		defaultlives = lives;
		lives_Percentage = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		direction = Input.GetAxis ("Horizontal");

		if (direction > 0f) {
			player.velocity = new Vector2 (direction * speed, player.velocity.y);
		} 

		else if (direction < 0f) {
			player.velocity = new Vector2 (direction * speed, player.velocity.y);
		} 

		else {
			player.velocity = new Vector2 (0, player.velocity.y);
		}

		if (Input.GetKeyDown (KeyCode.W) && on_ground == true) {
			player.AddForce(Vector2.up*250);
			on_ground = false;
		}
		Debug.Log (lives);
		livescounter.text =(lives_Percentage*100).ToString ()+"%";
		HealthBar.fillAmount = lives_Percentage;
	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		//Debug.Log("Player Collided with map!");
		on_ground = true;
	}
	void resetPosition(){
		Debug.Log ("SPIKE RECIEVED!");
		if (candie == false) {
			transform.SetPositionAndRotation (new Vector3 (-29.5f, -3.5f, 0f), Quaternion.identity);
			DamageSpike ();
		}
	}

	public void DamageSpike(){
		lives -= 1f;
		lives_Percentage = (lives / defaultlives);
		if (lives <= 0) {
			candie = true;
			Debug.Log ("End of game");
			MyAnimator.Play ("death");
			SceneManager.LoadScene ("Lost");
		}
	}
	public void DamageEnemy(){
		lives -= 0.5f;
		lives_Percentage = (lives / defaultlives);
		if (lives <= 0) {
			candie = true;
			Debug.Log ("End of game");
			MyAnimator.Play ("death");
			SceneManager.LoadScene ("Lost");
		}
	}
}