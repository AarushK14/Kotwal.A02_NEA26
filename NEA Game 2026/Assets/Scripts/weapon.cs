using UnityEngine;

public class weapon: MonoBehaviour
{
	[SerializeField] private Transform aimTransform; // The weapon (to rotate)
	[SerializeField] private GameObject arrowprefab; // Arrow prefab
	[SerializeField] private Transform spawnpos; // Where to spawn the arrow
	[SerializeField] private float speed = 5f;

	void Update()
	{
		RotateWeaponToMouse();

		if (Input.GetKeyDown(KeyCode.S))
		{
			ShootArrow();
		}
	}

	void RotateWeaponToMouse()
	{
		Vector3 mousePos = GetMouseWorldPosition ();
		Vector3 direction = (mousePos - aimTransform.position).normalized;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

		aimTransform.rotation = Quaternion.Euler(0, 0, angle);
	}

	void ShootArrow()
	{
		Vector3 mousePos = GetMouseWorldPosition();
		Vector3 direction = (mousePos - spawnpos.position).normalized;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

		GameObject arrow = Instantiate(arrowprefab, spawnpos.position, Quaternion.Euler(0f, 0f, angle));
		arrow.AddComponent<shoot>();
	}

	Vector3 GetMouseWorldPosition()
	{
		Vector3 mouseScreen = Input.mousePosition;
		mouseScreen.z = 10f; // Distance from camera
		return Camera.main.ScreenToWorldPoint(mouseScreen);
	}
}
	