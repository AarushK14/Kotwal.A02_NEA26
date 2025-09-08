﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Play() {
		Debug.Log("Button A clicked!");
		SceneManager.LoadScene ("Difficulty Selection");
	}

	public void Settings() {
		Debug.Log("Settings Clicked");
		SceneManager.LoadScene ("Settings");
	}

	public void Leaderboard() {
		Debug.Log ("Leaderboard Clicked!");
		SceneManager.LoadScene ("Leaderboard");
	}

	public void Tutorial() {
		Debug.Log ("Tutorial clicked!");
		SceneManager.LoadScene ("Tutorial");
	}
}
