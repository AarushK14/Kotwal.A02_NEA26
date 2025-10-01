using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created: Sprint 2 - Last Edited: Sprint 2
// Purpose: To allow the gun to follow the camera and rotate the correct way

public class weapon : MonoBehaviour
{
	[SerializeField] private Transform aimTransform;
	[SerializeField] private GameObject arrowprefab;
	[SerializeField] private Transform spawnpos;
	[SerializeField] private float speed = 5f;

	private Vector3 moveDirection;
	private GameObject currentArrow;

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
		Vector3 direction = (mousePos - aimTransform.position).normalized;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		aimTransform.rotation = Quaternion.Euler(0, 0, angle);
	}

	void ShootArrow()
	{
		Vector3 mousePos = GetMouseWorldPosition();
		Vector3 direction = (mousePos - spawnpos.position).normalized;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

		currentArrow = Instantiate(arrowprefab, spawnpos.position, Quaternion.Euler(0f, 0f, angle));
		moveDirection = direction.normalized;
	}

	Vector3 GetMouseWorldPosition()
	{
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 10f;
		return Camera.main.ScreenToWorldPoint(mousePos);
	}
}

	