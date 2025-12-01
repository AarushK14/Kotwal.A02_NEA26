using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
	float ArrowSpeed = 8.5f;
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