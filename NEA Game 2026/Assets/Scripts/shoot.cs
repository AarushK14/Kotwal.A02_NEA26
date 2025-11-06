using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created: Sprint 2 - Last Edited: Sprint 4
// Purpose: To manage the movement of the bullet eg speed etc...

public class shoot : MonoBehaviour
{

	[SerializeField] private GameObject arrowprefab;
	public Transform spawnpos;
	[SerializeField] private float speed = 5f;
	private Vector3 moveDirection;

	void Start()
	{
		Vector3 mousePos = GetMouseWorldPosition();
		Vector3 direction = (mousePos - spawnpos.position).normalized;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		moveDirection = direction.normalized;
	}

	void Update()
	{
		transform.position += moveDirection * speed * Time.deltaTime;
	}
	Vector3 GetMouseWorldPosition()
	{
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 10f;
		return Camera.main.ScreenToWorldPoint(mousePos);
	}

	public void OnCollisionEnter2D(Collider2D other){
		if (other.gameObject.tag == "enemy") {
			
		}
	}
}