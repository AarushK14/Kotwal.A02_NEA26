using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// Created: Sprint 1 - Last Edited: Sprint 2
// Purpose: To navigate between different scenes

public class Navigation : MonoBehaviour {

	public GameObject[] arr={};
	int index;
	private GameObject sprite;
	// Use this for initialization
	void Start () {
		index = 1;
	}
	
	// Update is called once per frame
	void Update () {
		sprite = arr[index];
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

	public void Easy() {
		Debug.Log ("Easy selected!");
		SceneManager.LoadScene ("Easy lvl 1");
	}
	public void Medium() {
		Debug.Log ("Medium selected!");
		SceneManager.LoadScene ("Normal lvl 1");
	}
	public void Hard() {
		Debug.Log ("Hard selected!");
		SceneManager.LoadScene ("Hard lvl 1");
	}
	public void MainMenu() {
		Debug.Log ("Return back to main menu");
		SceneManager.LoadScene ("Title and Menu");
	}

	public void Profile() {
		Debug.Log ("Profile clicked");
		SceneManager.LoadScene ("profiles");
	}
	public void Next(){
		Debug.Log ("Next clicked");
		while (index>=0 && index<=2)
			index++;
	}		
}
