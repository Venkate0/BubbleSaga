using UnityEngine;

public class MovingMan : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float jumpForce = 5f;
    public Transform groundCheck; 
    public float groundCheckRadius = 0.1f; 
    public LayerMask groundLayer; 
    public string horizontalInput = "Horizontal"; 
    public string jumpInput = "Jump"; 
    public TMPro.TextMeshProUGUI scoreText;
    private Vector2 movement;
    private Rigidbody2D rb; 
    private bool isGrounded; 
    private int score = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is missing on the player!");
        }

        rb.gravityScale = 3; 
    }

    void Update()
    {
        
        movement.x = Input.GetAxis(horizontalInput);

        
        isGrounded = IsGrounded();

        // Handle jumping
        if (Input.GetButtonDown(jumpInput) && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Apply horizontal movement
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Set vertical velocity directly
    }

    private bool IsGrounded()
    {
        // Check if the player is touching the ground layer
        Collider2D groundCollider = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Check if the player is standing on an object tagged "Wooden Box"
        Collider2D boxCollider = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius);

        if (groundCollider != null || (boxCollider != null && boxCollider.CompareTag("Wooden Box")))
        {
            return true;
        }

        return false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player touches a coin
        if (collision.gameObject.CompareTag("fruits"))
        {
            // Destroy the coin
            Destroy(collision.gameObject);

            // Increase the score
            score += 1;

            // Update the score display
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        // Update the UI text with the current score
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
