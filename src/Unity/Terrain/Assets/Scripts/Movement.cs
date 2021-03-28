using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private Rigidbody _body;

    private void Update()
    {
        Vector3 frontBackVelocity = Vector3.zero;
        Vector3 leftRightVelocity = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            frontBackVelocity = transform.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            frontBackVelocity = transform.forward * -1;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            leftRightVelocity = transform.right * -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            leftRightVelocity = transform.right;
        }

        Vector3 velocity = (frontBackVelocity + leftRightVelocity).normalized * _speed;

        _body.velocity = velocity;
    }
}
