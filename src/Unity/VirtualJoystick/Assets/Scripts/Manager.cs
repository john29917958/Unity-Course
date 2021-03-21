using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
	public float MoveSpeed;
	public VirtualJoystick Joystick;
	public Image Character;

	private bool _isMoving;
	
	private void Start()
    {
		Joystick.OnDragStarted += delegate () { _isMoving = true; };
		Joystick.OnDragEnded += delegate () { _isMoving = false; };
	}

	private void Update()
    {
		if (Input.GetMouseButtonDown(0))
        {
			Joystick.gameObject.SetActive(true);
			Joystick.transform.position = Input.mousePosition;
        }

		if (Input.GetMouseButtonUp(0))
        {
			Joystick.gameObject.SetActive(false);
		}
    }

	private void FixedUpdate()
    {
		if (_isMoving) MoveCharacter(Joystick.Direction);
    }

	private void MoveCharacter(Vector2 direction)
    {
		Character.transform.position += Vector3.ClampMagnitude(new Vector3(direction.x, direction.y, 0), MoveSpeed);
	}
}
