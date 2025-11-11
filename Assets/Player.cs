using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float xInput;
    private float yInput;
    private Rigidbody2D rb;

    private Animator anim;

    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private bool isFacingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        HandleInput();
        HandleMovement();
        HandleAnimation();
        HandleFlip();
    }

    private void HandleAnimation()
    {
        bool isMoving = rb.linearVelocity.x != 0;

        anim.SetBool("isMoving", isMoving);
        
    }

    private void HandleInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void HandleMovement()
    {
        rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private bool isMovingRight()
    {
        if(rb.linearVelocity.x == 0)
            return isFacingRight;
        return rb.linearVelocity.x > 0;
    }

    private void HandleFlip()
    {
        if (isMovingRight() && !isFacingRight)
            Flip();
        else if(!isMovingRight() && isFacingRight)
            Flip();
    }
    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
}
