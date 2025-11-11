using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator anim;

    [Header("Movement Details")]

    private float xInput;
    //private float yInput;
    private bool isFacingRight = true;

    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private float jumpForce = 8f;


    [Header("Collision Detection")]

    private bool isGrounded;

    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        HandleCollisions(); //call before anything
        HandleInput();
        HandleMovement();
        HandleAnimation();
        HandleFlip();
    }

    private void HandleCollisions()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void HandleAnimation()
    {

        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("xVelocity", rb.linearVelocity.x);
        anim.SetFloat("yVelocity", rb.linearVelocity.y);

    }

    private void HandleInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        //yInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void HandleMovement()
    {
        rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        if (isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private bool isMovingRight()
    {
        if (rb.linearVelocity.x == 0)
            return isFacingRight;
        return rb.linearVelocity.x > 0;
    }

    private void HandleFlip()
    {
        if (isMovingRight() && !isFacingRight)
            Flip();
        else if (!isMovingRight() && isFacingRight)
            Flip();
    }
    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckDistance));
    }
}
