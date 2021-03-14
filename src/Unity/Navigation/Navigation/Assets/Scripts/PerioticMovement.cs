using UnityEngine;

public class PerioticMovement : MonoBehaviour
{
	public Transform Anchor1;
	public Transform Anchor2;
	public float Speed;

	private Transform _target;
	private bool _isHit;
	
	void Start()
    {
		_target = Anchor1;
	}

	void Update ()
	{	
		if ((transform.position - Anchor1.position).magnitude <= 1 || (transform.position - Anchor2.position).magnitude <= 1)
        {
			_isHit = true;
		}
		
		if (_isHit)
        {
			_isHit = false;
			_target = _target == Anchor1 ? Anchor2 : Anchor1;
        }

		Vector3 direction = (_target.position - transform.position).normalized;
		direction *= Speed;
		transform.position += direction;
	}
}
