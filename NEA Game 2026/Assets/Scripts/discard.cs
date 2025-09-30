using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created: Sprint 2 - Last Edited: Sprint 2
// Purpose: To spawn the bullet and rotate the player's weapon based on the cursor position

public class follow : MonoBehaviour
{/*
	[SerializeField] private Transform aimTransform;
	public GameObject spawn;
	private Vector3 spawnposition;
	[SerializeField] GameObject arrow;

	private GameObject bulletInst;

	private Vector3 GetMouseWorldPosition()
	{
		Vector3 screenPos = Input.mousePosition;
		screenPos.z = 10f; // Distance to camera
		return Camera.main.ScreenToWorldPoint(screenPos);
	}

	private void start()
	{
		
	}

	private void Update()
	{
		rotation ();

		if (Input.GetKeyDown(keycode.S)){
			shoot ();
		}
	}

	private void rotation()
	{
		Vector3 mousePos = GetMouseWorldPosition();
		Vector3 aim = (mousePos - aimTransform.position).normalized; // normalised returns the vector with magnitude of 1
		float angle = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg; // gets the angle at which the gun is to be rotated
		aimTransform.eulerAngles = new Vector3(0, 0, angle); // used to rotate the gun sprite towards the mouse location by rotatating it by respectives angle

		Vector3 localscale = new Vector3 (1f, 1f, 1f);
		if (aimTransform.rotation.z > 90 || aimTransform.rotation.z < -90) {
			localscale.y = -1f;
		} 
		else {
			localscale.y = 1f;
		}
		aimTransform.localScale = localscale;
	}

	public void shoot()
		{
			Vector3 mousePos = GetMouseWorldPosition();
		Vector3 direction = (mousePos - spawnposition.position).normalized;
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

		GameObject arrow = Instantiate(arrow, spawnposition.position, Quaternion.Euler(0f, 0f, angle));
			arrow.AddComponent<ArrowMover>().Initialize(direction, 5);
		}

	Vector3 GetMouseWorldPosition()
		{
			Vector3 mouseScreen = Input.mousePosition;
			mouseScreen.z = 10f; // Distance from camera
			return Camera.main.ScreenToWorldPoint(mouseScreen);
		}
	}
}

public class ArrowMover : MonoBehaviour
{
	private Vector3 moveDirection;
	private float speed;

	public void Initialize(Vector3 dir, float spd)
	{
		moveDirection = dir.normalized;
		speed = spd;
	}

	void Update()
	{
		transform.position += moveDirection * speed * Time.deltaTime;
	}
*/}
