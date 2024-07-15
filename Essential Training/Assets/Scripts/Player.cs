using UnityEngine;

public class Player : MonoBehaviour
{
    private float xAxis;
    [SerializeField] private float speed;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        PlayerMovement();
        PlayerFlip();
    }

    private void PlayerMovement()
    {
        xAxis = Input.GetAxisRaw("Horizontal");

        // Move the player horizontally
        Vector3 movement = new Vector3(xAxis, 0f, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void PlayerFlip()
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
        // No need to handle flip when xAxis == 0 (stay facing the current direction)
    }
}
