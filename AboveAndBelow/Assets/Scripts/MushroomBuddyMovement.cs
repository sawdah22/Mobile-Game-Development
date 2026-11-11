using UnityEngine;

public class MushroomBuddyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    public Transform groundPlatform;

    private Rigidbody2D rb;
    private float moveInput;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;
    private bool isUnderground = false;

    private Color normalColour;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        normalColour = spriteRenderer.color;

    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        if (MobileControls.horizontalInput != 0)
        {             
            moveInput = MobileControls.horizontalInput;
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        animator.SetBool("isGrounded", isGrounded);

        if ((Input.GetKeyDown(KeyCode.Space) || MobileControls.jumpPressed) && isGrounded)
        {
            float jumpDirection = isUnderground ? -1f : 1f;

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce * jumpDirection);
        }

        MobileControls.jumpPressed = false;

        if (Input.GetKeyDown(KeyCode.F) || MobileControls.flipPressed)
        {
            FlipWorld();
        }

        MobileControls.flipPressed = false;

        animator.SetBool("isWalking", moveInput != 0);
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void FlipWorld()
    {
        if (groundPlatform == null)
        {
            Debug.LogWarning("Ground platform has not been assigned!");
            return;
        }

        isUnderground = !isUnderground;

        float platformY = groundPlatform.position.y;
        float platformHalfHeight = groundPlatform.localScale.y / 2f;
        float playerHalfHeight = GetComponent<Collider2D>().bounds.extents.y;
        float distance = platformHalfHeight + playerHalfHeight + 0.1f;

        if (isUnderground)
        {
            transform.position = new Vector3(transform.position.x, platformY - distance, transform.position.z);

            transform.rotation = Quaternion.Euler(0, 0, 180);
            rb.gravityScale = -1f;

            spriteRenderer.color = new Color(0.5f, 0.35f, 0.65f, 1f);
        }

        else
        {
            transform.position = new Vector3(transform.position.x, platformY + distance, transform.position.z);

            transform.rotation = Quaternion.identity;
            rb.gravityScale = 1f;

            spriteRenderer.color = normalColour;
        }
            rb.linearVelocity = Vector2.zero;
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
