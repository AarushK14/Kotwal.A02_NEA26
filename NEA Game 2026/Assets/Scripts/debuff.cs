using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debuff : MonoBehaviour {

	public GameObject Debuff;
	public GameObject player;
	private control ControlScript;

	// Use this for initialization
	void Start () {
		ControlScript = GetComponent < control >();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
			Destroy (this.gameObject);
			ControlScript.PlayerSpeed = 3f;
		}
	}
}
