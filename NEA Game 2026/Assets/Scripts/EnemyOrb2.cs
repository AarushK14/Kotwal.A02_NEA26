using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOrb2 : MonoBehaviour {

	public Transform orbSpawnPos;
	private Transform target;
	public float Orbspeed;
	GameObject player;

	// Use this for initialization
	void Awake(){
		print ("Orb awake");
	}

	void Start () {
		print ("Orb start");

		Orbspeed = 7f;
		player = GameObject.FindGameObjectWithTag("Player");
		transform.position = new Vector3 (orbSpawnPos.position.x, orbSpawnPos.position.y, orbSpawnPos.position.z);
	}

	// Update is called once per frame
	void Update () {
		target = player.transform;
		float distance = Orbspeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, distance);
	}

	void OnDestroy()
	{

		print ("i was destroyed");

	}
}