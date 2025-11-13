using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

// Created: Sprint 1 - Last Edited: Sprint 4
// Purpose: To allow character move based on the key pressed and add playability to the game.

public class control : MonoBehaviour {

	public float PlayerSpeed;
	private float direction = 0f;
	private Rigidbody2D player;
	public bool on_ground;
	float lives = 10;
	Animator MyAnimator;
	private bool candie;
	public TextMeshPro livescounter;
	private float lives_Percentage;
	private float defaultlives;
	public Image HealthBar;
	public GameObject enemy;
	public GameObject debuff;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D> ();
		MyAnimator = GetComponent<Animator> ();
		on_ground = true;
		candie = false;
		defaultlives = lives;
		lives_Percentage = 1;
		PlayerSpeed = 10f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		direction = Input.GetAxis ("Horizontal");

		if (direction > 0f) {
			player.velocity = new Vector2 (direction * PlayerSpeed, player.velocity.y);
		} 

		else if (direction < 0f) {
			player.velocity = new Vector2 (direction * PlayerSpeed, player.velocity.y);
		} 

		else {
			player.velocity = new Vector2 (0, player.velocity.y);
		}

		if (Input.GetKeyDown (KeyCode.W) && on_ground == true) {
			player.AddForce(Vector2.up*378);
			on_ground = false;
		}
		Debug.Log (lives);
		livescounter.text =(Mathf.Round(lives_Percentage*100)).ToString ()+"%";
		HealthBar.fillAmount = lives_Percentage;
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene("pause");
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		//Debug.Log("Player Collided with map!");
		on_ground = true;
	}
	void resetPosition(){
		Debug.Log ("SPIKE RECIEVED!");
		if (candie == false) {
			transform.SetPositionAndRotation (new Vector3 (-53.13f, -2.8f, 0f), Quaternion.identity);
			DamageSpike ();
		}
	}

	public void DamageSpike(){
		MyAnimator.Play ("hit");

		lives -= 1f;
		lives_Percentage = (lives / defaultlives);
		if (lives <= 0) {
			candie = true;
			Debug.Log ("End of game");
			MyAnimator.Play ("death");
			SceneManager.LoadScene ("Lost");
		}
	}

	public void DamageEnemy(float damage){
		
		StartCoroutine(hit());
		lives -= damage;
		lives_Percentage = (lives / defaultlives);
		if (lives <= 0) {
			candie = true;
			Debug.Log ("End of game");
			MyAnimator.Play ("death");
			SceneManager.LoadScene ("Lost");
		}
	}

	IEnumerator hit(){
		yield return new WaitForSeconds (0.2f);
		MyAnimator.Play ("hit");
	}

	IEnumerator regen(){
		while (lives <= 9.5f) {
			yield return new WaitForSeconds (3);
			lives += 0.3f;
		}
	}

	IEnumerator OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "debuff") {
			PlayerSpeed = 3f;
			yield return new WaitForSeconds (8f);
			PlayerSpeed = 10f;
		}
	}
}