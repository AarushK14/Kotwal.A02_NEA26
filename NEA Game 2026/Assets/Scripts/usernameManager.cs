using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Created: Sprint 6 - Last Edited: Sprint 6
// Purpose: Used to allow users to set a username for themselves

public class usernameManager : MonoBehaviour {

	private string input;
	static List<int> scores =  new List<int> {};

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void readInput(string username){
		input = username;
		Debug.Log (input);
		PlayerPrefs.SetString ("user", input);
		Debug.Log (PlayerPrefs.GetString ("user", ""));
		scores.Add (PlayerPrefs.GetInt("userScore"));
	}
}