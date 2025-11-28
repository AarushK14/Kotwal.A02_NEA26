using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created: Sprint 2 - Last Edited: Sprint 4
// Purpose: To manage the movement of the bullet eg speed etc...

public class shoot : MonoBehaviour
{

	public Transform spawnpos;
	float ArrowSpeed;
	private Vector3 moveDirection;
	private DifficultySystem VariableRef;

	void Start()
	{
		VariableRef = GetComponent<DifficultySystem> ();
		Vector3 mousePos = GetMouseWorldPosition();
		Vector3 direction = (mousePos - spawnpos.position).normalized;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		moveDirection = direction.normalized;
		ArrowSpeed = VariableRef.ArrowSpeed;
	}

	void Update()
	{
		transform.position += moveDirection * ArrowSpeed * Time.deltaTime;
	}

	Vector3 GetMouseWorldPosition()
	{
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 10f;
		return Camera.main.ScreenToWorldPoint(mousePos);
	}
}