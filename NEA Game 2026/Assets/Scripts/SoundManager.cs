using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	private AudioSource audioControl;
	public AudioClip arrowShoot;
	public AudioClip arrowHit;
	public AudioClip freeze;
	public AudioClip hurt;
	public AudioClip healthPickup;
	public AudioClip general;
	public AudioClip firerate;
	public AudioClip coin;

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

	void freezeDebuff(){
		audioControl.PlayOneShot (freeze);
	}

	void hurtSound(){
		audioControl.PlayOneShot (hurt);
	}

	void health(){
		audioControl.PlayOneShot (healthPickup);
	}

	void generlaBuffDebuff(){
		audioControl.PlayOneShot (general);
	}

	void fireRateBuff(){
		audioControl.PlayOneShot (firerate);
	}

	void coinPickup(){
		audioControl.PlayOneShot (coin);
	}
}
