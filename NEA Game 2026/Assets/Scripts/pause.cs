using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Created: Sprint 3 - Last Edited: Sprint 4
// Purpose: controlling the pause menu and what different buttons would do

public class pause : MonoBehaviour {

	public GameObject PauseMenu;
	bool paused = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (paused) {
				resume ();
			} 
			else {
				Pause ();			
			}
		}
	}

	public void Pause(){
		PauseMenu.SetActive(true);
		Time.timeScale = 0f;
		paused = true;
	}

	public void resume(){
		PauseMenu.SetActive(false);
		Time.timeScale = 1f;
		paused = false;
	}

	public void restart(){
		SceneManager.LoadScene ("tutorial");
	}
}
