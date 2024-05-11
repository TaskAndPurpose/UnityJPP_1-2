using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _movementSpeed = 5.0f;
    [SerializeField] private float _rotationSpeed = 100.0f;
    [SerializeField] private Vector3 _movementDirection;



    void Update()
    {
        HandleInput();
    }

    void FixedUpdate()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        HandleMovementInput();
        HandleRotationInput();
    }

    private void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        _movementDirection = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;
    }

    private void HandleMovement(Vector3 direction)
    {
        Vector3 movement = direction * _movementSpeed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + movement);
    }

    private void HandleRotationInput()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            RotatePlayer(-_rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            RotatePlayer(_rotationSpeed * Time.deltaTime);
        }
    }

    private void RotatePlayer(float rotationAmount)
    {
        transform.Rotate(Vector3.up, rotationAmount);
    }
}
