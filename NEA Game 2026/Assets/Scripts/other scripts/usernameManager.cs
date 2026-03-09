using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Created: Sprint 6 - Last Edited: Sprint 6
// Purpose: Used to allow users to set a username for themselves

public class usernameManager : MonoBehaviour {

	private string input;

	// Function to capture the username from an input field
	public void readInput(string username){
		input = username;
		Debug.Log (input);
		// Saves the entered username to PlayerPrefs
		PlayerPrefs.SetString ("user", input);
		Debug.Log (PlayerPrefs.GetString ("user", ""));
	}
}