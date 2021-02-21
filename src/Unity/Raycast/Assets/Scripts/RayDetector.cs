using UnityEngine;

public class RayDetector : MonoBehaviour {
	public LayerMask LayerMask;
	public float RayDistance = 5;

	// Use this for initialization
	private void Start ()
	{
		
	}
	
	// Update is called once per frame
	private void Update ()
	{
		Vector3 origin = transform.position;
		Vector3 direction = transform.TransformDirection(Vector3.forward);
		Ray ray = new Ray(origin, direction);

		RaycastHit hitInfo;
		if (Physics.Raycast(ray, out hitInfo, RayDistance, LayerMask))
		{
			Debug.Log(string.Format("Hit \"{0}\" at {1}. Hit point: {2}", hitInfo.transform.name, hitInfo.transform.position, hitInfo.point));
		}

		DrawRay(ray);
	}

	private void DrawRay(Ray ray)
    {
		Debug.DrawRay(ray.origin, ray.direction * RayDistance, Color.red);
    }
}
