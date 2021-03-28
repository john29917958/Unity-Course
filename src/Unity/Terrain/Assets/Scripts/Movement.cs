using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;

    [SerializeField]
    private float _rotationSpeed;

    [SerializeField]
    private GameObject _headV;

    [SerializeField]
    private GameObject _headH;

    [SerializeField]
    private Rigidbody _body;

    private void FixedUpdate()
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

        Vector3 velocity = (frontBackVelocity + leftRightVelocity).normalized * _moveSpeed;

        _body.velocity = velocity;        
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse X") > 0.1f)
        {
            // Mouse moves right
            _headH.transform.Rotate(Vector3.up, _rotationSpeed);
        }
        else if (Input.GetAxis("Mouse X") < -0.1f)
        {
            // Mouse moves left
            _headH.transform.Rotate(Vector3.down, _rotationSpeed);
        }        

        if (Input.GetAxis("Mouse Y") > 0.1f)
        {
            // Mouse moves up
            _headV.transform.Rotate(Vector3.left, _rotationSpeed);
        }
        else if (Input.GetAxis("Mouse Y") < -0.1f)
        {
            // Mouse moves down
            _headV.transform.Rotate(Vector3.right, _rotationSpeed);
        }
    }
}
