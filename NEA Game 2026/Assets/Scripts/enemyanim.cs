using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyanim : MonoBehaviour {

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

	private void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			MyAnimator.SetTrigger ("attack");
		}
	}
	private void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			MyAnimator.SetTrigger ("idle");
		}
	}
}
