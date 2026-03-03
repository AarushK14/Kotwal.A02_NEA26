using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeManager : MonoBehaviour {

	public Slider volumeSlider; // The UI slider for volume control

	// Use this for initialization
	void Start () {
		// Sets a default volume if the game is being played for the first time
		if (!PlayerPrefs.HasKey ("volume")) {
			PlayerPrefs.SetFloat ("volume", 0.5f);
		} else {
			// Otherwise, loads the previously saved volume
			Load ();
		}
	}

	// Adjusts the master audio level based on the slider position
	public void changeVolume(){
		AudioListener.volume = volumeSlider.value;
		Save ();
	}

	// Retrieves the saved volume value from PlayerPrefs
	private void Load(){
		volumeSlider.value = PlayerPrefs.GetFloat ("volume",0);
	}

	// Stores the current slider value in PlayerPrefs
	private void Save(){
		PlayerPrefs.SetFloat ("volume", volumeSlider.value);
	}
}