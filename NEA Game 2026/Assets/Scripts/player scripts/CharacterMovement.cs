using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

// Created: Sprint 1 - Last Edited: Sprint 5
// Purpose: To allow character move based on the key pressed and add playability to the game.

public class CharacterMovement : MonoBehaviour {

	// defining attributes
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
	SpriteRenderer m_SpriteRenderer;
	public TextMeshProUGUI debuffText;
	float attackTime;
	float jumpForce;
	public TextMeshProUGUI instructions;
	public TextMeshProUGUI Tip;
	public Transform spawnPointer;
	Vector3 spawnPoint;
	private DifficultySystem variableRef;
	bool vulnerable;
	private string objectName;
	private Transform orbSpawnPos;
	private Transform enemy2;
	public TextMeshProUGUI coincounter; // UI text for the coin count
	int coinCount; // Starting number of coins

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D> (); // used to access the rigidbody component of the object
		MyAnimator = GetComponent<Animator> (); // gets the animator component of the object
		variableRef = GetComponent<DifficultySystem> (); // imports the difficuty system script
		on_ground = true; // sets the boolean to true initially which indicates that the player is on the ground
		can_Die = false; // this is a boolean which tells if the player is vulerable and can die, this is initially set to false
		lives = variableRef.lives; // sets the life of the player equal to the integer set in the difficulty system script
		defaultlives = lives;
		lives_Percentage = 1;
		PlayerSpeed = 10;
		m_SpriteRenderer = GetComponent<SpriteRenderer> ();
		attackTime = Time.fixedTime;
		jumpForce = variableRef.jumpForce;
		if (SceneManager.GetActiveScene ().name == "tutorial") { // checks is the current scene is tutorial
			instructions.text = "Press A/D to move and W to jump"; // if so, it sets the appropriate instructions.
		}
		spawnPoint = spawnPointer.position; // sets the spawn point of the player
		vulnerable = false;
		coinCount = 0;
		// Finds the UI element for the coin counter
		coincounter = GameObject.FindGameObjectWithTag ("coinCounter").GetComponent<TextMeshProUGUI>();
	}

	// Update is called once per frame
	void Update () 
	{
		direction = Input.GetAxis ("Horizontal");

		if (direction > 0f) {
			player.velocity = new Vector2 (direction * PlayerSpeed, player.velocity.y); // moves left if the direction is left
		} 

		else if (direction < 0f) {
			player.velocity = new Vector2 (direction * PlayerSpeed, player.velocity.y); // moves right if the direction is right
		} 

		else {
			player.velocity = new Vector2 (0, player.velocity.y); // if not moving towards any direction, it stays at rest
		}

		if (Input.GetKeyDown (KeyCode.W) && on_ground == true) { // checks to see if the player is on ground and if the W key is pressed.
			player.AddForce(Vector2.up*jumpForce);
			on_ground = false; // this bit of code set the on_ground bool as false the second the player jumps, to prevent players from jumping indefinitely
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "";
			}
		}
		livescounter.text =(Mathf.Round(lives_Percentage*100)).ToString (); // converts the health of the player into a percentage and updates the text holder with the %age
		HealthBar.fillAmount = lives_Percentage; // fills the image with the same percentage as the player health
		// Updates the UI display
		coincounter.text = "Coins: " + coinCount.ToString ();
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		on_ground = true; // sets the on_ground bool to true when the player collides with the tilemap
	}

	void resetPosition(){
		player.SendMessage ("hurtSound");
		if (can_Die == false) { // checks if the player can die
			transform.SetPositionAndRotation (spawnPoint, Quaternion.identity); // resets the position of the player after collision with a spike
			DamageSpike (); // executes the method DamageSpike
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "You got spiked!"; // checks if the active scene is tutorial, if so, updates the instructions text to appropriate message
			}
		}
	}

	public void DamageSpike(){
		MyAnimator.Play ("hit"); // plays the animation hit
		lives -= 1f; // reduces the lives by 1
		lives_Percentage = (lives / defaultlives); // updates the lifes fraction
		if (lives <= 0 || vulnerable == true) {
			can_Die = true;
			Debug.Log ("End of game");
			MyAnimator.Play ("death");
			SceneManager.LoadScene ("Lost"); // if no lives left, it loads the lost scene
		}
	}

	void OnTriggerStay2D(Collider2D other){
		// Check if the thing touching us is an enemy AND if enough time has passed to be hit again
		if (other.gameObject.tag == "enemy" && attackTime <= Time.fixedTime-2){
			attackTime = Time.fixedTime; // Reset the attack timer to current time
			StartCoroutine(hit()); // Run the hit animation routine
			lives -= 0.5f; // Subtract half a life point
			lives_Percentage = (lives / defaultlives); // Update the math for the health bar

			// If lives are out OR if the instant death debuff is active, trigger death
			if (lives <= 0 || vulnerable == true) {
				can_Die = true;
				Debug.Log ("End of game");
				MyAnimator.Play ("death"); // Start death animation
				SceneManager.LoadScene ("Lost"); // Go to the game over screen
			}
			// If this is happening in the tutorial, update the UI text
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "you're under attack! shoot to kill them";
			}
		}
	}

	IEnumerator hit(){
		MyAnimator.Play ("hit"); // Play the "getting hurt" animation
		yield return new WaitForSeconds (0.5f); // Wait for half a second before finishing
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		// If the player touches the "slow" object
		if (other.gameObject.tag == "slow") {
			objectName = other.gameObject.tag; // Save the tag name for the timer
			player.SendMessage ("generalBuffDebuff"); // Tell the player script to play a sound/effect
			// Try to find the score manager to record a debuff was picked up
			scoreController scoreManager = GameObject.FindGameObjectWithTag ("Player").GetComponent<scoreController> ();
			if (scoreManager != null) {
				scoreManager.buffsDebuffs();
			}
			m_SpriteRenderer.color = Color.red; // Turn the player red
			debuffText.text = debuffText.text + "Slow"; // Add "Slow" to the UI list
			PlayerSpeed = 3f; // Lower the movement speed
			// Check if we need to show tutorial instructions
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "This is debuff, it slows you down";
			}
			StartCoroutine (CountDown ()); // Start the timer to undo this effect

			// If the player touches the "speed" object instead
		} else if (other.gameObject.tag == "speed") {
			objectName = other.gameObject.tag;
			player.SendMessage ("generalBuffDebuff");
			scoreController scoreManager = GameObject.FindGameObjectWithTag ("Player").GetComponent<scoreController> ();
			if (scoreManager != null) {
				scoreManager.buffsDebuffs();
			}
			m_SpriteRenderer.color = Color.cyan; // Turn the player light blue
			PlayerSpeed = 15f; // Increase movement speed
			jumpForce = 500; // Increase jump height
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "This is a buff! It increases your speed and jump";
			}
			StartCoroutine (CountDown ());
		} 

		// Separate check for "freeze" tag
		if (other.gameObject.tag == "freeze") {
			objectName = other.gameObject.tag;
			player.SendMessage ("freezeDebuff");
			scoreController scoreManager = GameObject.FindGameObjectWithTag ("Player").GetComponent<scoreController> ();
			if (scoreManager != null) {
				scoreManager.buffsDebuffs();
			}
			m_SpriteRenderer.color = Color.blue; // Turn the player dark blue
			debuffText.text = debuffText.text + "freeze";
			player.constraints = RigidbodyConstraints2D.FreezePosition; // Lock the player in place
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "This is another debuff, it freezes";
			}
			StartCoroutine (CountDown ());
		} 

		// Check for the "instantDeath" trap
		if (other.gameObject.tag == "instantDeath") {
			objectName = other.gameObject.tag;
			player.SendMessage ("health");
			scoreController scoreManager = GameObject.FindGameObjectWithTag ("Player").GetComponent<scoreController> ();
			if (scoreManager != null) {
				scoreManager.buffsDebuffs();
			}
			m_SpriteRenderer.color = Color.yellow; // Turn the player yellow
			debuffText.text = debuffText.text + "instant death";
			vulnerable = true; // Set flag so the next hit kills the player
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "This is another debuff, it kills you instantly";
			}
			StartCoroutine (CountDown ());

			// If it's the "fullHealth" pickup instead
		} else if (other.gameObject.tag == "fullHealth") {
			objectName = other.gameObject.tag;
			player.SendMessage ("health");
			scoreController scoreManager = GameObject.FindGameObjectWithTag ("Player").GetComponent<scoreController> ();
			if (scoreManager != null) {
				scoreManager.buffsDebuffs();
			}
			m_SpriteRenderer.color = Color.green; // Turn the player green
			lives = defaultlives; // Reset lives to max
			lives_Percentage = (lives / defaultlives); // Update health UI
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "This is a buff! it increases your health";
			}
			StartCoroutine (CountDown ());

			// If it's the fire rate power up
		} else if (other.gameObject.tag == "firerate") {
			objectName = other.gameObject.tag;
			player.SendMessage ("fireRateBuff");
			scoreController scoreManager = GameObject.FindGameObjectWithTag ("Player").GetComponent<scoreController> ();
			if (scoreManager != null) {
				scoreManager.buffsDebuffs();
			}
			m_SpriteRenderer.color = Color.gray; // Turn the player gray
			GetComponent<weaponManager> ().BuffActiveTrue (); // Enable fast shooting in the weapon script
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "This is a buff! it increases your firerate";
			}
			StartCoroutine (CountDown ());
			// If the player touches the coin
		} else if (other.gameObject.tag == "coin") {
			objectName = other.gameObject.tag;
			coinCount += 1;
			Destroy (other.gameObject);
			player.SendMessage ("coinPickup");
			// Only show the coin tip if we are in the tutorial scene
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				Tip.text = "Tip: This is a coin! it increases your score";
				StartCoroutine (CountDown ());
			}
			// If the player reaches the "alter" (the level exit)
		} else if (other.gameObject.tag == "alter") {
			objectName = other.gameObject.tag;
			// Check current level name to decide which scene to load next
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				SceneManager.LoadScene ("Difficulty selection");
			}
			if (SceneManager.GetActiveScene ().name == "lvl 1") {
				SceneManager.LoadScene ("lvl 2");
			}
			if (SceneManager.GetActiveScene ().name == "lvl 2") {
				SceneManager.LoadScene ("Win");
			}
		}
		// If player falls into a respawn zone
		if (other.gameObject.tag == "tilemap_respawn") {
			transform.SetPositionAndRotation (spawnPoint, Quaternion.identity); // Move player back to start
			objectName = other.gameObject.tag;
		}
		// If hit by an enemy projectile (orb)
		if (other.gameObject.tag == "enemyOrb") {
			lives -= 0.5f; // Take damage
			player.SendMessage("hurtSound");
			lives_Percentage = (lives / defaultlives);
			// Check if dead or vulnerable
			if (lives <= 0 || vulnerable == true) {
				can_Die = true;
				Debug.Log ("End of game");
				MyAnimator.Play ("death");
				SceneManager.LoadScene ("Lost");
				scoreController scoreManager = GameObject.FindGameObjectWithTag ("Player").GetComponent<scoreController> ();
				if (scoreManager != null) {
					scoreManager.resetScore();
				}
			}
		}
		// If touching a key, remove the key from the game
		if (other.gameObject.tag == "key") {
			Destroy (other.gameObject);
			scoreController scoreManager = GameObject.FindGameObjectWithTag ("Player").GetComponent<scoreController> ();
			if (scoreManager != null) {
				scoreManager.keyPickup();
			}
		}
	}

	// Handles timers to reset player stats after a buff or debuff expires
	IEnumerator CountDown(){
		// Reset movement and colors after a "slow" effect
		if (objectName == "slow") {
			yield return new WaitForSeconds (6f);
			PlayerSpeed = 10f;
			m_SpriteRenderer.color = Color.white;
			debuffText.text = "Active Debuff: ";
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "";
			}
		}
		// Restore movement constraints after being frozen
		if (objectName == "freeze") {
			yield return new WaitForSeconds (3f);
			player.constraints = RigidbodyConstraints2D.FreezeRotation; // Allow movement again
			m_SpriteRenderer.color = Color.white;
			debuffText.text = "Active Debuff: ";
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "";
			}
		}
		// Remove the one-hit-kill vulnerability
		if (objectName == "instantDeath") {
			yield return new WaitForSeconds (5f);
			m_SpriteRenderer.color = Color.white;
			vulnerable = false;
			debuffText.text = "Active Debuff: ";
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "";
			}
		}
		// Revert speed and jump height to defaults
		if (objectName == "speed") {
			yield return new WaitForSeconds (8f);
			PlayerSpeed = 10f;
			jumpForce = 380f;
			m_SpriteRenderer.color = Color.white;
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "";
			}
		}
		// Reset player color after a health pickup
		if (objectName == "fullHealth") {
			yield return new WaitForSeconds (8f);
			m_SpriteRenderer.color = Color.white;
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "";
			}
		}
		// Return shooting speed to normal
		if (objectName == "firerate") {
			yield return new WaitForSeconds (5f);
			m_SpriteRenderer.color = Color.white;
			GetComponent<weaponManager> ().BuffActiveFalse (); // Call weapon reset
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "";
			} 
		}
		// Clear the coin tip from the tutorial UI
		if (objectName == "coin") {
			yield return new WaitForSeconds (3f);
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				Tip.text = "";
			}
		}
		// Clear specific enemy tutorial messages
		if (objectName == "enemy2Range") {
			yield return new WaitForSeconds (5f);
			if (SceneManager.GetActiveScene ().name == "tutorial") {
				instructions.text = "";
			}
		}
	}
}
