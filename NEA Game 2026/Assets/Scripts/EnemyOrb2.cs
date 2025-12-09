using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOrb2 : MonoBehaviour {

	public float speed = 1f;
	public Transform player;
	public  Transform SpawnPos;
	private Transform target; 

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(SpawnPos.position.x,SpawnPos.position.y,SpawnPos.position.z);
		target = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
		float distance = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, distance);
	}
}
