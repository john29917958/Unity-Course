using UnityEngine;

public class RayDetector : MonoBehaviour {
	public LayerMask LayerMask;
	public float RayDistance = 5;
	
	// Update is called once per frame
	private void Update ()
	{
		DetectRayCollision();
	}

	private void DetectRayCollision()
    {
		Vector3 origin = transform.position;
		Vector3 direction = transform.TransformDirection(Vector3.forward);

		Ray ray = new Ray(origin, direction);

		foreach (RaycastHit hitInfo in Physics.RaycastAll(ray, RayDistance, LayerMask))
		{
			Debug.Log(string.Format("Hit \"{0}\" at {1}. Hit point (world): {2}, hit point (screen): {3}, hit point (viewport): {4}.",
				hitInfo.transform.name,
				hitInfo.transform.position,
				hitInfo.point,
				Camera.main.WorldToScreenPoint(hitInfo.point),
				Camera.main.WorldToViewportPoint(hitInfo.point)
			));
		}

		DrawRay(ray);
	}

	private void DrawRay(Ray ray)
    {
		Debug.DrawRay(ray.origin, ray.direction * RayDistance, Color.red);
    }
}
