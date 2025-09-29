using UnityEngine;

public class Gunfollow : MonoBehaviour
{
	[SerializeField] private Transform aimTransform;

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
		Vector3 mousePos = GetMouseWorldPosition();
		Vector3 aim = (mousePos - aimTransform.position).normalized; // normalised returns the vector with magnitude of 1
		float angle = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg; // gets the angle at which the gun is to be rotated
		while (-100f<angle && angle<100f){
			aimTransform.eulerAngles = new Vector3(0, 0, angle); // used to rotate the gun sprite towards the mouse location by rotatating it by respectives angle
		}

		if (Input.GetKeyDown (KeyCode.A)) {
			transform.rotation = Quaternion.Euler (0f, 180f, 0f);
		}

		if (Input.GetKeyDown (KeyCode.D)) {
			transform.rotation = Quaternion.Euler (0f, 0f, 0f);
		}
	}
}