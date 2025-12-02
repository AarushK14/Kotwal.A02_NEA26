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
	float lives;
	Animator MyAnimator;
	private bool can_Die;
	public TextMeshProUGUI livescounter;
	private float lives_Percentage;
	private float defaultlives;
	public Image HealthBar;
	public GameObject enemy;
	public GameObject debuff;
	SpriteRenderer m_SpriteRenderer;
	public TextMeshProUGUI debuffText;
	float attackTime;
	float jumpForce;
	public TextMeshProUGUI instructions;
	public TextMeshProUGUI Tip;
	public Transform spawnPointer;
	Vector3 spawnPoint;
	private DifficultySystem variableRef;
	public float knockbackForce;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D> ();
		MyAnimator = GetComponent<Animator> ();
		variableRef = GetComponent<DifficultySystem> ();
		on_ground = true;
		can_Die = false;
		lives = variableRef.lives;
		defaultlives = lives;
		lives_Percentage = 1;
		PlayerSpeed = 10;
		m_SpriteRenderer = GetComponent<SpriteRenderer> ();
		attackTime = Time.fixedTime;
		jumpForce = variableRef.jumpForce;
		if (SceneManager.GetActiveScene ().name == "tutorial") {
			instructions.text = "Press A/D to move and W to jump";
		}
		spawnPoint = spawnPointer.position;

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
			player.AddForce(Vector2.up*jumpForce);
			on_ground = false;
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "";
			}
		}

		Debug.Log (lives);
		livescounter.text =(Mathf.Round(lives_Percentage*100)).ToString ()+"%";
		HealthBar.fillAmount = lives_Percentage;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log("Player Collided with map!");
		on_ground = true;
	}

	void resetPosition(){
		Debug.Log ("SPIKE RECIEVED!");
		if (can_Die == false) {
			transform.SetPositionAndRotation (spawnPoint, Quaternion.identity);
			DamageSpike ();
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "You got spiked!";
			}
		}
	}

	public void DamageSpike(){
		MyAnimator.Play ("hit");

		lives -= 1f;
		lives_Percentage = (lives / defaultlives);
		if (lives <= 0) {
			can_Die = true;
			Debug.Log ("End of game");
			MyAnimator.Play ("death");
			SceneManager.LoadScene ("Lost");
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "enemy" && attackTime <= Time.fixedTime-2){
			attackTime = Time.fixedTime;
			StartCoroutine(hit());
			lives -= 0.5f;
			lives_Percentage = (lives / defaultlives);
			if (lives <= 0) {
				can_Die = true;
				Debug.Log ("End of game");
				MyAnimator.Play ("death");
				SceneManager.LoadScene ("Lost");
			}
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "you're under attack! shoot to kill them";
			}
		}
	}

	IEnumerator hit(){
		MyAnimator.Play ("hit");
		yield return new WaitForSeconds (0.5f);
	}

	IEnumerator OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "debuff") {
			m_SpriteRenderer.color = Color.red;
			debuffText.text = debuffText.text + "Slow";
			PlayerSpeed = 3f;
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "This is debuff, it slows you down";
			}
			yield return new WaitForSeconds (8f);
			PlayerSpeed = 10f;
			m_SpriteRenderer.color = Color.white;
			debuffText.text = "Active Debuff: ";
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "";
			}
		} 

		else if (other.gameObject.tag == "buff") {
			m_SpriteRenderer.color = Color.green;
			PlayerSpeed = 15f;
			jumpForce = 500;
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "This is a buff!";
			}
			yield return new WaitForSeconds (8f);
			PlayerSpeed = 10f;
			jumpForce = 380f;
			m_SpriteRenderer.color = Color.white;
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "";
			}
		} 

		else if (other.gameObject.tag == "coin") {
			Tip.text = "Tip: This is a coin! it increases your score";
			yield return new WaitForSeconds (3f);
			Tip.text = "";
		} 

		else if (other.gameObject.tag == "alter") {
			SceneManager.LoadScene ("lvl 1");
		}
	}

	IEnumerator CountDown(){
		yield return new WaitForSeconds (2);
	}

	void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.tag == "map") {
			if (lives < 9.5f) {
				lives += 0.3f;
				lives_Percentage = (lives / defaultlives);
				StartCoroutine (CountDown ());
			}
		}
	}
}