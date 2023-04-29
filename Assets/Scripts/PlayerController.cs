using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody _rigidbody;
    private int _count;
    private float _movementX;
    private float _movementY;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    private void OnMove(InputValue movementValue)
    {
        var movementVector = movementValue.Get<Vector2>();

        _movementX = movementVector.x;
        _movementY = movementVector.y;
    }

    private void SetCountText()
    {
        countText.text = "Count: " + _count;
        if (_count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        var movement = new Vector3(_movementX, 0.0f, _movementY);
        
        _rigidbody.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("PickUp")) return;
        other.gameObject.SetActive(false);
        _count++;
        SetCountText();
    }
}
