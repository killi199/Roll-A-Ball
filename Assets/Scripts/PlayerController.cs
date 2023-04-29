using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody _rigidbody;
    private float _movementX;
    private float _movementY;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue movementValue)
    {
        var movementVector = movementValue.Get<Vector2>();

        _movementX = movementVector.x;
        _movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        var movement = new Vector3(_movementX, 0.0f, _movementY);
        
        _rigidbody.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
