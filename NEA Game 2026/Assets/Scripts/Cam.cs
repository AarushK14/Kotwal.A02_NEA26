using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created: Sprint 2 - Last Edited: Sprint 2
// Purpose: To allow the camera to follow the player.

public class Cam : MonoBehaviour {

	public GameObject player;
	public float offset;
	public float offsetSmoothing;
	private Vector3 Playerposition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3, -10f);

		Playerposition = new Vector3 (player.transform.position.x, player.transform.position.y, -10f);

		if (player.transform.localScale.x > 0) {
			Playerposition = new Vector3 (Playerposition.x + offset, Playerposition.y, Playerposition.z);
		} 
		else {
			Playerposition = new Vector3 (Playerposition.x - offset, Playerposition.y, Playerposition.z);
		}
	}
}
