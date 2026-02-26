using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created: Sprint 2 - Last Edited: Sprint 4
// Purpose: To allow the camera to follow the player.

public class cameraManager : MonoBehaviour {

	public GameObject player;
	public float offset;
	private Vector3 Playerposition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.7f, -10f); // this would be used to update the cameras position

		Playerposition = new Vector3 (player.transform.position.x, player.transform.position.y, -10f); // this would get the players position as a 3d vector which would bhe sued to update the camer's position allowing the camera to follow the player

		// this IF statement would be used to move the camera to left / right by a set amount basied on where the character is facing, this would look cool and allow a nice transition whils plaaying the game.
		if (player.transform.localScale.x > 0) {
			Playerposition = new Vector3 (Playerposition.x + offset, Playerposition.y, Playerposition.z);
		} 
		else {
			Playerposition = new Vector3 (Playerposition.x - offset, Playerposition.y, Playerposition.z);
		}
	}
}
