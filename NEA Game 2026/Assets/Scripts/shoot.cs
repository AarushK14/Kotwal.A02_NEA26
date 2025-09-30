using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created: Sprint 2 - Last Edited: Sprint 2
// Purpose: To manage the movement of the bullet eg speed etc...

public class shoot : MonoBehaviour
{
	public float speed = 10f;

	private Vector3 moveDirection;

	void Start()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = 0f;

		Vector3 startPos = transform.position;
		moveDirection = (mousePos - startPos).normalized;
	}

	void Update()
	{
		transform.position += moveDirection * speed * Time.deltaTime;
	}
}
