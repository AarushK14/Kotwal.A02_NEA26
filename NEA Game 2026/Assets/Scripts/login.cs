using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class login : MonoBehaviour {

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
		scores.Add (PlayerPrefs.GetInt("userScore"));
	}
}