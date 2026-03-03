using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowController : MonoBehaviour
{
	float ArrowSpeed = 10f; // How fast the arrow flies
	private Vector3 moveDirection;

	// Sets which way the arrow should fly
	public void Direction(Vector3 dir)
	{
		moveDirection = dir.normalized;
	}

	void Update()
	{
		// Moves the arrow every frame based on speed and direction
		transform.position += moveDirection * ArrowSpeed * Time.deltaTime;
	}
}