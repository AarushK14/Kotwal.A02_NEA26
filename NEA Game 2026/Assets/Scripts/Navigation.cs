using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// Created: Sprint 1 - Last Edited: Sprint 6
// Purpose: To navigate between different scenes

public class Navigation : MonoBehaviour {

	private GameObject sprite;
	GameObject pauseMenu;
	public string CurrentScene;

	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene ().name == "tutorial" || SceneManager.GetActiveScene ().name == "lvl 1" || SceneManager.GetActiveScene ().name == "lvl 2" || SceneManager.GetActiveScene ().name == "lvl 3") {
			pauseMenu = GameObject.FindGameObjectWithTag ("pauseMenu");
			pauseMenu.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			pauseMenu.SetActive(true);
			Time.timeScale = 0f;
		}
	}

	// this would take you to the difficulty selection scene
	public void Play() {
		SceneManager.LoadScene ("profiles");
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

	// this will take you to the difficulty selection screen
	public void DifficultySelection() {
		Debug.Log ("Loading difficulty selection");
		SceneManager.LoadScene ("Difficulty selection");
	}

	// this bit of code will take you to the tutoral where you can learn the contols of the game
	public void Tutorial() {
		Debug.Log ("Tutorial clicked!");
		Time.timeScale = 1f;
		SceneManager.LoadScene ("tutorial");
		Debug.Log(PlayerPrefs.GetString("user"));
	}

	// when in the difficulty selection scene, this would take you to the easy level
	public void Easy() {
		Debug.Log ("Easy selected!");
		Time.timeScale = 1f;
		PlayerPrefs.SetInt ("difficulty", 1);
		SceneManager.LoadScene ("lvl 1");
		Debug.Log(PlayerPrefs.GetInt ("difficulty"));
	}

	// this would take you to the medium difficulty levels
	public void Medium() {
		Debug.Log ("Medium selected!");
		Time.timeScale = 1f;
		PlayerPrefs.SetInt ("difficulty", 2);
		SceneManager.LoadScene ("lvl 1");
		Debug.Log(PlayerPrefs.GetInt ("difficulty"));
	}

	// this will take you to the hard levels
	public void Hard() {
		Debug.Log ("Hard selected!");
		Time.timeScale = 1f;
		PlayerPrefs.SetInt ("difficulty", 3);
		SceneManager.LoadScene ("lvl 1");
		Debug.Log(PlayerPrefs.GetInt ("difficulty"));
	}

	// this would get attacted to the back button which allows the player to go back to the main menu if they wish to
	public void MainMenu() {
		Debug.Log ("Return back to main menu");
		SceneManager.LoadScene ("Title and Menu");
		Score scoreManager = GameObject.FindGameObjectWithTag ("Player").GetComponent<Score> ();
		if (scoreManager != null) {
			scoreManager.resetScore();
		}
	}
		
	public void resume(){
		Time.timeScale = 1f;
		pauseMenu.SetActive (false);
	}

	public void restart(){
		CurrentScene = SceneManager.GetActiveScene ().name;
		SceneManager.LoadScene (CurrentScene);
		Time.timeScale = 1f;
		Score scoreManager = GameObject.FindGameObjectWithTag ("Player").GetComponent<Score> ();
		if (scoreManager != null) {
			scoreManager.resetScore();
		}
	}
}
