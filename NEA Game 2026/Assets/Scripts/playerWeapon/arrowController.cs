using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowController : MonoBehaviour
{
	float ArrowSpeed = 10f;
	private Vector3 moveDirection;

	public void Direction(Vector3 dir)
	{
		moveDirection = dir.normalized;
	}

	void Update()
	{
		transform.position += moveDirection * ArrowSpeed * Time.deltaTime;
	}
}