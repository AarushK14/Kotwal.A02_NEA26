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

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		direction = Input.GetAxis ("Horizontal");

		if (direction > 0f) {
			player.velocity = new Vector2 (direction * speed, player.velocity.y);
		} else if (direction < 0f) {
			player.velocity = new Vector2 (direction * speed, player.velocity.y);
		} else {
			player.velocity = new Vector2 (0, player.velocity.y);
		}

		if (Input.GetButtonDown ("Jump")) {
			player.velocity = new Vector2 (player.velocity.x, jumpspeed);
		}
	}
}
