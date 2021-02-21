using UnityEngine;

public class Movement : MonoBehaviour
{
	public float Speed = 5;
	public float RotationSpeed = 50;

	// Update is called once per frame
	private void FixedUpdate ()
	{
		if (Input.GetKey(KeyCode.W))
		{
			Vector3 direction = transform.TransformDirection(Vector3.forward);
			Vector3 movement = direction * Speed * Time.fixedDeltaTime;
			transform.position += movement;
		}
		else if (Input.GetKey(KeyCode.S))
		{
			Vector3 direction = transform.TransformDirection(Vector3.back);
			Vector3 movement = direction * Speed * Time.fixedDeltaTime;
			transform.position += movement;
		}

		if (Input.GetKey(KeyCode.A))
		{
			Vector3 direction = transform.TransformDirection(Vector3.down);
			Vector3 rotation = direction * RotationSpeed * Time.fixedDeltaTime;

			transform.eulerAngles += rotation;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			Vector3 direction = transform.TransformDirection(Vector3.up);
			Vector3 rotation = direction * RotationSpeed * Time.fixedDeltaTime;

			transform.eulerAngles += rotation;
		}
	}
}
