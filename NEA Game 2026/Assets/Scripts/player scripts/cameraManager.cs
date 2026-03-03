using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created: Sprint 2 - Last Edited: Sprint 4
// Purpose: To allow the camera to follow the player.

public class cameraManager : MonoBehaviour {

	public GameObject player;
	public float offset; // Distance the camera looks ahead
	private Vector3 Playerposition;

	// Update is called once per frame
	void Update () {

		// Basic follow: sets camera position directly to player with a small height boost
		transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.7f, -10f); 

		// Gets the current player position to calculate the look-ahead offset
		Playerposition = new Vector3 (player.transform.position.x, player.transform.position.y, -10f); 

		// Shifts the camera view left or right based on which way the player is facing
		if (player.transform.localScale.x > 0) {
			Playerposition = new Vector3 (Playerposition.x + offset, Playerposition.y, Playerposition.z);
		} 
		else {
			Playerposition = new Vector3 (Playerposition.x - offset, Playerposition.y, Playerposition.z);
		}
	}
}