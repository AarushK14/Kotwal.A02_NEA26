using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Created: Sprint 2 - Last Edited: Sprint 4
// Purpose: Controlling the coin, destroying them on collision and also incrementing the coin counter.

public class coin : MonoBehaviour {
	
	public GameObject Player;
	public TextMeshProUGUI coincounter;
	GameObject [] Tcoins;
	int y;
	int x;
	int found;

	// Use this for initialization
	void Start () {
		Tcoins = GameObject.FindGameObjectsWithTag ("coin");
		y = Tcoins.Length;
	}
	
	// Update is called once per frame
	void Update () {
		Tcoins = GameObject.FindGameObjectsWithTag ("coin");
		x = Tcoins.Length;
		found = y - x;
		coincounter.text = "Coins: " + found.ToString ();
	}

	private void OnTriggerEnter2D(Collider2D other){ 
		if (other.gameObject.tag == "Player"){
			found = y - x;
			Debug.Log ("Coins found:" + (found+1));
			Destroy (this.gameObject);
		}
	}
}
	