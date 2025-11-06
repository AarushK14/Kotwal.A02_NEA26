using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created: Sprint 2 - Last Edited: Sprint 4
// purpose - used to allow the player to respawn when the players interacts with a spike

public class spikes : MonoBehaviour {

	private void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log("Spiked!");
		Hero.SendMessage("resetPosition");
	}
	GameObject Hero;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		Hero = GameObject.FindGameObjectWithTag("Player");
	}
}