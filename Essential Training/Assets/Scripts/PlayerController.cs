using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xAxis;
    public float yAxis;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] public float jumpForce = 2f;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded; // To check if the player is on the ground
    private Animator animator;
    [SerializeField]
    float yAxisMultiplier = 5f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>(); // Ensure rigidBody is assigned
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        playerMovement();
        playerFlip();
        playerJump();
    }

    private void playerMovement()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxis("Vertical");
        float yAxisMultiplier = 2f; // Adjust this value as needed to exert more force on the y-axis

        Vector3 movement = new Vector3(xAxis, yAxis * yAxisMultiplier, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);

        if (xAxis != 0)
        {
            animator.SetInteger("AnimState", 1); // Walking
        }
        else if (yAxis != 0)
        {
            animator.SetInteger("AnimState", 2); // Moving vertically
        }
        else
        {
            animator.SetInteger("AnimState", 0); // Idle
        }
    }

    private void playerFlip()
    {
        // Flip sprite based on movement direction
        if (xAxis > 0)
        {
            // Face right
            spriteRenderer.flipX = false;
        }
        else if (xAxis < 0)
        {
            // Face left
            spriteRenderer.flipX = true;
        }
    }

    private void playerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; // Assume the player is in the air once they jump
        }
    }

    // Check if the player is on the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5)
        {
            isGrounded = true; // Player is grounded if they collide with something below
        }
    }
}
