using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debuffController : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	// Runs when a 2D object enters the trigger area
	void OnTriggerEnter2D(Collider2D other){
		// Checks if the object has the "Player" tag
		if (other.gameObject.tag == "Player"){
			// Deletes the debuff object from the scene
			Destroy (this.gameObject);
		}
	}
}
