using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	private AudioSource audioControl; // The component that plays the sounds
	public AudioClip arrowShoot;
	public AudioClip arrowHit;
	public AudioClip freeze;
	public AudioClip hurt;
	public AudioClip healthPickup;
	public AudioClip BuffDebuff;
	public AudioClip firerate;
	public AudioClip coin;

	// Use this for initialization
	void Start () {
		// Get the AudioSource component from this object
		audioControl = GetComponent<AudioSource> ();	
	}

	// Play sound when an arrow is fired
	void arrowShootSound(){
		audioControl.PlayOneShot (arrowShoot);
	}

	// Play sound when an arrow hits something
	void arrowHitSound(){
		audioControl.PlayOneShot (arrowHit);
	}

	// Play sound for the freeze debuff
	void freezeDebuff(){
		audioControl.PlayOneShot (freeze);
	}

	// Play sound when the player takes damage
	void hurtSound(){
		audioControl.PlayOneShot (hurt);
	}

	// Play sound when picking up health
	void health(){
		audioControl.PlayOneShot (healthPickup);
	}

	// Play sound for general status changes
	void generalBuffDebuff(){
		audioControl.PlayOneShot (BuffDebuff);
	}

	// Play sound for the fire rate power-up
	void fireRateBuff(){
		audioControl.PlayOneShot (firerate);
	}

	// Play sound when a coin is collected
	void coinPickup(){
		audioControl.PlayOneShot (coin);
	}
}