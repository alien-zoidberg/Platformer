using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float jumpForce = 1200;

    [SerializeField]
    float walkSpeed = 10;

    float movementX = 0;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.linearVelocityX = movementX * walkSpeed;
    }

    void OnJump(InputValue value)
    {
        rb.AddForce(Vector2.up * jumpForce);
    }

    void OnMove(InputValue value)
    {
        movementX = value.Get<Vector2>().x;
    }
}