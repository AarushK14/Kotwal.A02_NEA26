using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created: Sprint 1 - Last Edited: Sprint 1
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
		
		Playerposition = new Vector3 (player.transform.position.x, player.transform.position.y, -10f);

		if (player.transform.localScale.x > 0) {
			Playerposition = new Vector3 (Playerposition.x + offset, Playerposition.y, Playerposition.z);
		} 
		else {
			Playerposition = new Vector3 (Playerposition.x - offset, Playerposition.y, Playerposition.z);
		}

		transform.position = new Vector3 (Playerposition.x, player.transform.position.y, -10f);
	}
}
