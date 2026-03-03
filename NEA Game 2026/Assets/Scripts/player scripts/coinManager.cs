using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Created: Sprint 2 - Last Edited: Sprint 4
// Purpose: Controlling the coin, destroying them on collision and also incrementing the coin counter.

public class coinManager : MonoBehaviour {

	public GameObject Player;
	public TextMeshProUGUI coincounter; // UI text for the coin count
	GameObject [] Tcoins; // Array to hold all coins in the scene
	int y; // Starting number of coins
	int x; // Current number of coins
	int found; // Number of coins collected

	// Use this for initialization
	void Start () {
		// Finds all objects tagged "coin" at the start
		Tcoins = GameObject.FindGameObjectsWithTag ("coin");
		y = Tcoins.Length;
		// Finds the UI element for the coin counter
		coincounter = GameObject.FindGameObjectWithTag ("coinCounter").GetComponent<TextMeshProUGUI>();
	}

	// Update is called once per frame
	void Update () {
		// Constantly checks how many coins are left in the scene
		Tcoins = GameObject.FindGameObjectsWithTag ("coin");
		x = Tcoins.Length;
		// Calculates how many have been picked up
		found = y - x;
		// Updates the UI display
		coincounter.text = "Coins: " + found.ToString ();
	}

	private void OnTriggerEnter2D(Collider2D other){ 
		// If the player touches the coin
		if (other.gameObject.tag == "Player"){
			found = y - x;
			// Remove the coin from the game
			Destroy (this.gameObject);
		}
	}
}