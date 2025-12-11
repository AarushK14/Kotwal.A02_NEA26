using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	private AudioSource audioControl;
	public AudioClip arrowShoot;
	public AudioClip arrowHit;

	// Use this for initialization
	void Start () {
		audioControl = GetComponent<AudioSource> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void arrowShootSound(){
		audioControl.PlayOneShot (arrowShoot);
	}

	void arrowHitSound(){
		audioControl.PlayOneShot (arrowHit);
	}
}
