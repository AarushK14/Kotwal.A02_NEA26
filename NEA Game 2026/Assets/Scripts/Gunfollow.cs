using UnityEngine;

public class Gunfollow : MonoBehaviour
{
	[SerializeField] private Transform aimTransform;
	[SerializeField] private GameObject bullet;

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

}