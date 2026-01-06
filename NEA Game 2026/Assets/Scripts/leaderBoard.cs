using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class leaderBoard : MonoBehaviour {

	private string input;

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
	}
}