using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

// Created: Sprint 1 - Last Edited: Sprint 4
// Purpose: To allow character move based on the key pressed and add playability to the game.

public class CharacterMovement : MonoBehaviour {

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
	bool vulnerable;
	private string objectName;

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
		vulnerable = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		weapon w = GetComponent<weapon> ();
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
		if (lives <= 0 || vulnerable == true) {
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
			if (lives <= 0 || vulnerable == true) {
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

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "debuff") {
			objectName = other.gameObject.tag;
			m_SpriteRenderer.color = Color.red;
			debuffText.text = debuffText.text + "Slow";
			PlayerSpeed = 3f;
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "This is debuff, it slows you down";
			}
			StartCoroutine (CountDown ());

		} else if (other.gameObject.tag == "buff") {
			objectName = other.gameObject.tag;
			m_SpriteRenderer.color = Color.cyan;
			PlayerSpeed = 15f;
			jumpForce = 500;
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "This is a buff!";
			}
			StartCoroutine (CountDown ());
		} 

		if (other.gameObject.tag == "debuff2") {
			objectName = other.gameObject.tag;
			m_SpriteRenderer.color = Color.blue;
			debuffText.text = debuffText.text + "freeze";
			player.constraints = RigidbodyConstraints2D.FreezePosition;
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "This is another debuff, it freezes";
			}
			StartCoroutine (CountDown ());
		} 

		if (other.gameObject.tag == "debuff3") {
			objectName = other.gameObject.tag;
			m_SpriteRenderer.color = Color.yellow;
			debuffText.text = debuffText.text + "instant death";
			vulnerable = true;
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "This is another debuff, it kills you instantly";
			}
			StartCoroutine (CountDown ());
		
		} else if (other.gameObject.tag == "buff2") {
			objectName = other.gameObject.tag;
			m_SpriteRenderer.color = Color.green;
			lives = defaultlives;
			lives_Percentage = (lives / defaultlives);
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "This is a buff! it increases your health";
			}

		} else if (other.gameObject.tag == "buff3") {
			objectName = other.gameObject.tag;
			m_SpriteRenderer.color = Color.gray;
			GetComponent<weapon> ().BuffActiveTrue ();
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "This is a buff! it increases your firerate";
			}
			StartCoroutine (CountDown ());
		} else if (other.gameObject.tag == "coin") {
			objectName = other.gameObject.tag;
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				Tip.text = "Tip: This is a coin! it increases your score";
				StartCoroutine (CountDown ());
			}
		} else if (other.gameObject.tag == "alter") {
			SceneManager.LoadScene ("lvl 1");
			objectName = other.gameObject.tag;
		}
		if (other.gameObject.tag == "tilemap_respawn") {
			transform.SetPositionAndRotation (spawnPoint, Quaternion.identity);
			objectName = other.gameObject.tag;
		}
	}

	IEnumerator CountDown(){
		if (objectName == "debuff") {
			yield return new WaitForSeconds (8f);
			PlayerSpeed = 10f;
			m_SpriteRenderer.color = Color.white;
			debuffText.text = "Active Debuff: ";
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "";
			}
		}
		if (objectName == "debuff2") {
			yield return new WaitForSeconds (8f);
			player.constraints = RigidbodyConstraints2D.FreezeRotation;
			m_SpriteRenderer.color = Color.white;
			debuffText.text = "Active Debuff: ";
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "";
			}
		}
		if (objectName == "debuff3") {
			yield return new WaitForSeconds (5f);
			m_SpriteRenderer.color = Color.white;
			vulnerable = false;
			debuffText.text = "Active Debuff: ";
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "";
			}
		}
		if (objectName == "buff") {
			yield return new WaitForSeconds (8f);
			PlayerSpeed = 10f;
			jumpForce = 380f;
			m_SpriteRenderer.color = Color.white;
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "";
			}
		}
		if (objectName == "buff2") {
			yield return new WaitForSeconds (8f);
			m_SpriteRenderer.color = Color.white;
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "";
			}
		}
		if (objectName == "buff3") {
			yield return new WaitForSeconds (5f);
			m_SpriteRenderer.color = Color.white;
			GetComponent<weapon> ().BuffActiveFalse ();
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "";
			} 
		}
		if (objectName == "coin") {
			yield return new WaitForSeconds (3f);
			Tip.text = "";
		}
	}
}