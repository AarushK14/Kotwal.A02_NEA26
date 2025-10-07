using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created: Sprint 2 - Last Edited: Sprint 2
// Purpose: 

public class coin : MonoBehaviour {

	GameObject [] TotalCoins;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2d(Collision2D other){
		if (other.gameObject.tag == "monkey"){
			Destroy (this.gameObject);
		}
	}
}
