using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created: Sprint 2 - Last Edited: Sprint 4
// purpose - used to allow the player to respawn when the players interacts with a spike

public class spikeManager : MonoBehaviour {

	// Detects when the player physically touches the spike
	private void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log("Spiked!");
		// Tells the player script to run the resetPosition function
		Hero.SendMessage("resetPosition");
	}

	GameObject Hero;

	// Update is called once per frame
	void Update () {
		// Constantly finds the player object in the scene
		Hero = GameObject.FindGameObjectWithTag("Player");
	}
}