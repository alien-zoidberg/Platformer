using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float jumpForce = 1200;

    [SerializeField]
    float walkSpeed = 10;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    LayerMask groundLayer;

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
        if(Physics2D.OverlapPoint(groundCheck.position, groundLayer))
        {   
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    void OnMove(InputValue value)
    {
        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();

        movementX = value.Get<Vector2>().x;

        sr.flipX = movementX < 0;
    }
}