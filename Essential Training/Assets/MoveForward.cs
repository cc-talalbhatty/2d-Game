using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float speed;
    public float changeDirectionInterval = 2f; // Time in seconds to change direction
    private bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeDirectionRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        moveAlien();
    }

    public void moveAlien()
    {
        Vector2 direction = movingRight ? Vector2.right : Vector2.left;
        rigidbody.velocity = direction * speed * Time.deltaTime;
    }

    private IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeDirectionInterval);
            movingRight = !movingRight;
        }
    }
}
