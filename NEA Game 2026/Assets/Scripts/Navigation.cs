using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// Created: Sprint 1 - Last Edited: Sprint 4
// Purpose: To navigate between different scenes

public class Navigation : MonoBehaviour {

	private GameObject sprite;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	// this would take you to the difficulty selection scene
	public void Play() {
		Debug.Log("Button A clicked!");
		SceneManager.LoadScene ("Difficulty Selection");
	}

	// this would take you to the setting where you can customize contols
	public void Settings() {
		Debug.Log("Settings Clicked");
		SceneManager.LoadScene ("Settings");
	}

	// this is for the leaderboard button and would direct you to the leaderboard scene
	public void Leaderboard() {
		Debug.Log ("Leaderboard Clicked!");
		SceneManager.LoadScene ("Leaderboard");
	}

	// this bit of code will take you to the tutoral where you can learn the contols of the game
	public void Tutorial() {
		Debug.Log ("Tutorial clicked!");
		SceneManager.LoadScene ("Tutorial");
	}

	// when in the difficulty selection scene, this would take you to the easy level
	public void Easy() {
		Debug.Log ("Easy selected!");
		SceneManager.LoadScene ("Easy lvl 1");
	}

	// this would take you to the medium difficulty levels
	public void Medium() {
		Debug.Log ("Medium selected!");
		SceneManager.LoadScene ("Normal lvl 1");
	}

	// this will take you to the hard levels
	public void Hard() {
		Debug.Log ("Hard selected!");
		SceneManager.LoadScene ("Hard lvl 1");
	}

	// this would get attacted to the back button which allows the player to go back to the main menu if they wish to
	public void MainMenu() {
		Debug.Log ("Return back to main menu");
		SceneManager.LoadScene ("Title and Menu");
	}

	// this is for the profile button, it would direct you to the profiles menu where you can enter a username
	public void Profile() {
		Debug.Log ("Profile clicked");
		SceneManager.LoadScene ("profiles");
	}
}
