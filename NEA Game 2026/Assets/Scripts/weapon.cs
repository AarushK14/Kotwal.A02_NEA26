using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
	public Transform aimTransform;
	public GameObject arrowprefab;
	public Transform spawnpos;
	public bool buffActive;
	GameObject currentArrow;

	void Start(){
		buffActive = false;
	}

	void Update()
	{
		RotateWeaponToMouse();

		if (Input.GetMouseButtonDown(0))
		{
			ShootArrow();
		}
	}

	void RotateWeaponToMouse()
	{
		Vector3 mousePos = GetMouseWorldPosition();
		Vector2 direction = mousePos - aimTransform.position;

		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		aimTransform.rotation = Quaternion.Euler(0, 0, angle);
	}

	void ShootArrow()
	{
		if (buffActive == false) {
			if (currentArrow != null)
				return;
		}

		// Direction to mouse
		Vector3 mousePos = GetMouseWorldPosition();
		Vector3 direction = (mousePos - spawnpos.position).normalized;

		// Angle to rotate arrow
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

		// Instantiate arrow
		currentArrow = Instantiate(arrowprefab, spawnpos.position, Quaternion.Euler(0f, 0f, angle));

		// Send direction into shoot script
		shoot s = currentArrow.GetComponent<shoot>();
		s.Direction(direction);

		// Destroy after 1 second
		Destroy(currentArrow, 1f);
	}

	Vector3 GetMouseWorldPosition()
	{
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 10f;
		return Camera.main.ScreenToWorldPoint(mousePos);
	}
}
