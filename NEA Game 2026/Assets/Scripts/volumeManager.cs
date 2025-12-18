using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeManager : MonoBehaviour {

	public Slider volumeSlider;

	// Use this for initialization
	void Start () {
		if (!PlayerPrefs.HasKey ("volume")) {
			PlayerPrefs.SetFloat ("volume", 0.5f);
		} else {
			Load ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeVolume(){
		AudioListener.volume = volumeSlider.value;
		Save ();
	}

	private void Load(){
		volumeSlider.value = PlayerPrefs.GetFloat ("volume",0);
	}

	private void Save(){
		PlayerPrefs.SetFloat ("volume", volumeSlider.value);
	}
}
