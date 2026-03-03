using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponManager : MonoBehaviour
{
	public Transform aimTransform; // The pivot point for aiming the weapon
	public GameObject arrowprefab; // The arrow object to be fired
	public Transform spawnpos; // Where the arrow appears when shot
	public bool buffActive; // Checks if a power-up is active (like rapid fire)
	GameObject currentArrow;
	GameObject player;

	void Start(){
		buffActive = false;
		// Locates the player object at the start
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update()
	{
		// Constantly points the weapon toward the mouse cursor
		RotateWeaponToMouse();

		// Detects left-click to fire an arrow
		if (Input.GetMouseButtonDown(0))
		{
			ShootArrow();
		}
	}

	void RotateWeaponToMouse()
	{
		// Calculates the angle between the weapon and the mouse
		Vector3 mousePos = GetMouseWorldPosition();
		Vector2 direction = mousePos - aimTransform.position;

		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		// Applies the rotation to the weapon transform
		aimTransform.rotation = Quaternion.Euler(0, 0, angle);
	}

	void ShootArrow()
	{
		// If no buff is active, prevent shooting if an arrow is already in flight
		if (buffActive == false) {
			if (currentArrow != null)
				return;
		}

		// Calculate the direction from the spawn point to the mouse
		Vector3 mousePos = GetMouseWorldPosition();
		Vector3 direction = (mousePos - spawnpos.position).normalized;

		// Rotate the arrow to face the direction of flight
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

		// Create the arrow and play the firing sound
		currentArrow = Instantiate(arrowprefab, spawnpos.position, Quaternion.Euler(0f, 0f, angle));
		player.SendMessage ("arrowShootSound");

		// Tell the arrow script which direction to travel
		arrowController s = currentArrow.GetComponent<arrowController>();
		s.Direction(direction);

		// Automatically remove the arrow after 1 second
		Destroy(currentArrow, 1f);
	}

	// Converts mouse screen position to coordinates in the game world
	Vector3 GetMouseWorldPosition()
	{
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 10f;
		return Camera.main.ScreenToWorldPoint(mousePos);
	}

	// Enable the shooting buff
	public void BuffActiveTrue(){
		buffActive = true;
	}

	// Disable the shooting buff
	public void BuffActiveFalse(){
		buffActive = false;
	}
}