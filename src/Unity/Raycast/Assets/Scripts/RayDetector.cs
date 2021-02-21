using UnityEngine;

public class RayDetector : MonoBehaviour {
	public LayerMask LayerMask;
	public float RayDistance = 5;
	public float Speed = 5;

	// Use this for initialization
	private void Start ()
	{
		
	}
	
	// Update is called once per frame
	private void Update ()
	{
		DetectRayCollision();
	}

	private void FixedUpdate()
    {
		UpdateMovement();
    }

	private void DetectRayCollision()
    {
		Vector3 origin = transform.position;
		Vector3 direction = transform.TransformDirection(Vector3.forward);
		Ray ray = new Ray(origin, direction);

		foreach (RaycastHit hitInfo in Physics.RaycastAll(ray, RayDistance, LayerMask))
		{
			Debug.Log(string.Format("Hit \"{0}\" at {1}. Hit point: {2}", hitInfo.transform.name, hitInfo.transform.position, hitInfo.point));
		}

		DrawRay(ray);
	}

	private void DrawRay(Ray ray)
    {
		Debug.DrawRay(ray.origin, ray.direction * RayDistance, Color.red);
    }

	private void UpdateMovement()
    {
		if (Input.GetKey(KeyCode.UpArrow))
        {
			Vector3 direction = transform.TransformPoint(Vector3.forward) - transform.position;
			Vector3 movement = direction * Speed * Time.fixedDeltaTime;
			transform.position += movement;
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			Vector3 direction = transform.TransformPoint(Vector3.back) - transform.position;
			Vector3 movement = direction * Speed * Time.fixedDeltaTime;
			transform.position += movement;
		}

		if (Input.GetKey(KeyCode.LeftArrow))
        {

        }
    }
}
