using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Created: Sprint 2 - Last Edited: Sprint 2
// Purpose: Controlling the coin, destroying them on collision and also incrementing the coin counter.

public class coin : MonoBehaviour {

	public TextMeshPro coincounter;
	GameObject [] Tcoins;
	int y;
	int x;
	int found;

	// Use this for initialization
	void Start () {
		y = Tcoins.Length;
	}
	
	// Update is called once per frame
	void Update () {
		Tcoins = GameObject.FindGameObjectsWithTag ("coin");
		x = Tcoins.Length;
		coincounter.text = "Coins: " + found.ToString ();
	}

	private void OnTriggerEnter2d(Collision2D other){
		if (other.gameObject.tag == "Player"){
			found = y - x;
			Destroy (this.gameObject);
		}
	}
}
