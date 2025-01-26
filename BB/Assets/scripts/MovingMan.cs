using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingMan : MonoBehaviour
{
    public float moveSpeed = 5f; // Player movement speed
    public float jumpForce = 5f; // Force applied for jumping
    public Transform groundCheck; // Reference to the ground check position
    public LayerMask groundLayer; // Layer mask to determine what is considered ground
    public string horizontalInput = "Horizontal"; // Horizontal input axis
    public string jumpInput = "Jump"; // Jump input axis
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isGrounded;

    public string levelname;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 3; // Adjust this value to control fall speed
    }

    void Update()
    {
        // Horizontal movement
        movement.x = Input.GetAxis(horizontalInput);

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        Debug.Log("IsGrounded: " + isGrounded); // Log for verification

        // Handle jumping
        if (Input.GetButtonDown(jumpInput) && isGrounded)
        {
            Debug.Log("Jump button pressed and player is grounded"); // Log for jump detection
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // Use AddForce for jumping
        }
    }

    void FixedUpdate()
    {
        // Apply horizontal movement
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y); // Use velocity for consistent movement
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("fruits"))
        {
            SceneManager.LoadScene(levelname);
        }
    }




    void OnDrawGizmos()
    {
        // Draw the ground check circle
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, 0.1f);
        }
    }
}
