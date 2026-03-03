using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buffController : MonoBehaviour {

	public GameObject buffItem;
	public GameObject player;

	// Runs when something touches the buff item
	void OnTriggerEnter2D(Collider2D other){
		// Check if the thing touching it is the player
		if (other.gameObject.tag == "Player"){
			// Remove the buff from the scene
			Destroy (this.gameObject);
		}
	}
}