using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOrb2 : MonoBehaviour {

	private Transform target;
	public float Orbspeed;
	GameObject player;

	// Use this for initialization
	void Start () {
		Orbspeed = 7;
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update () {
		target = player.transform;
		float distance = Orbspeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, distance);
		Destroy (this.gameObject, 2f);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
			Destroy (this.gameObject);
		}
	}
}