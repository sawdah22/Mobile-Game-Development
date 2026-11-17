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
        if (!TutorialManager.canMove)
        {
            moveInput = 0f;
            MobileControls.horizontalInput = 0f;
            MobileControls.jumpPressed = false;
            MobileControls.flipPressed = false;
            return;
        }
        moveInput = Input.GetAxis("Horizontal");

        if (MobileControls.horizontalInput != 0)
        {             
            moveInput = MobileControls.horizontalInput;
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        animator.SetBool("isGrounded", isGrounded);

        if (TutorialManager.canJump && (Input.GetKeyDown(KeyCode.Space) || MobileControls.jumpPressed) && isGrounded)
        {
            float jumpDirection = isUnderground ? -1f : 1f;

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce * jumpDirection);
        }

        MobileControls.jumpPressed = false;

        if (TutorialManager.canFlip && (Input.GetKeyDown(KeyCode.F) || MobileControls.flipPressed))
        {
            FlipWorld();
        }

        MobileControls.flipPressed = false;

        animator.SetBool("isWalking", moveInput != 0);
        if (moveInput > 0)
        {
            spriteRenderer.flipX = isUnderground;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = !isUnderground;
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

        Collider2D groundCollider = groundPlatform.GetComponent<Collider2D>();

        if (groundCollider == null)
        {
            Debug.LogWarning("Ground platform has noCollider");
            return;
        }

        isUnderground = !isUnderground;

        float playerHalfHeight = GetComponent<Collider2D>().bounds.extents.y;
        float distance = playerHalfHeight + 0.1f;

        if (isUnderground)
        {
            float bottomOfGround = groundCollider.bounds.min.y;

            transform.position = new Vector3(transform.position.x, bottomOfGround - distance, transform.position.z);

            transform.rotation = Quaternion.Euler(0, 0, 180);
            rb.gravityScale = -1f;

            spriteRenderer.color = new Color(0.5f, 0.35f, 0.65f, 1f);
        }

        else
        {
            float topOfGround = groundCollider.bounds.max.y;

            transform.position = new Vector3(transform.position.x, topOfGround + distance, transform.position.z);

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
