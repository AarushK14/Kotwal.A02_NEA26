using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created: Sprint 3 - Last Edited: Sprint 4
// Purpose: Controlling the enemy, making sure they play the right animation and controlling which way they face based on users position

public class enemy : MonoBehaviour {

	public GameObject player;
	Animator MyAnimator;

	// Use this for initialization
	void Start () {
		MyAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x < transform.position.x) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
		} 
		else {
			transform.rotation = Quaternion.Euler (0, 180, 0);
		}
	}

	IEnumerator OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			MyAnimator.SetTrigger ("attack");
			yield return new WaitForSeconds (2f);
		}
	}
	private void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			MyAnimator.SetTrigger ("idle");
		}
	}
}
