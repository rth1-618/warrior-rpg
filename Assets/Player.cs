using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator anim;

    [Header("Attack Details")]
    [SerializeField] private float attackRadius;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask whatIsEnemy;

    [Header("Movement Details")]

    private float xInput;
    //private float yInput;
    private bool isFacingRight = true;

    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private float jumpForce = 8f;
    private bool canMove = true;
    private bool canJump = true;



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
            TryToJump();
        if (Input.GetKeyDown(KeyCode.Mouse0))
            TryToAttack();
    }


    private void HandleMovement()
    {
        if (canMove)
            rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
        else
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
    }

    public void DamageEnemies()
    {
        Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, whatIsEnemy);

        foreach(Collider2D enemy in enemyColliders)
        {
            enemy.GetComponent<Enemy>().TakeDamage();
        }
    }

    public void EnableMovementAndJump(bool enable = true)
    {
        canMove = enable;
        canJump = enable;

    }
    private void TryToAttack()
    {
        if (isGrounded)
            anim.SetTrigger("attack");
        
    }



    private void TryToJump()
    {
        if (isGrounded && canJump)
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
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
