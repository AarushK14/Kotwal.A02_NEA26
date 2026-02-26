using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour {

	Animator MyAnimator;

	// Use this for initialization
	void Start () {
		MyAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "arrow") {
			MyAnimator.SetTrigger ("chestOpened");
		}
	}
}