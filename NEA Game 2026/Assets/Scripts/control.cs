using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created: Sprint 1 - Last Edited: Sprint 2
// Purpose: To allow character move based on the key pressed and add playability to the game.

public class control : MonoBehaviour {

	public float speed = 5f;
	public float jumpspeed = 5f;
	private float direction = 0f;
	private Rigidbody2D player;
	public bool ong;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D> ();
		ong = true;
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

		if (Input.GetKeyDown (KeyCode.W) && ong == true) {
			player.AddForce(Vector2.up*250);
			ong = false;
		}
	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log("Player collided with map!");
		ong = true;
	}
	void resetPosition(){
		Debug.Log ("SPIKE RECIEVED!");
		transform.SetPositionAndRotation (new Vector3 (-29.5f, -3.5f, 0f), Quaternion.identity);
	}
}