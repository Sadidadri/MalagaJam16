using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform startPosition;
    public Transform endPosition;
    public float movementSpeed = 4f;

    private Rigidbody2D rb;
    private bool movingToEndPosition = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.position = startPosition.position;
    }

    private void Update()
    {
        // Determine the direction and distance between the enemy and the current target position.
        Vector2 direction = movingToEndPosition ? ((Vector2)endPosition.position - rb.position) : ((Vector2)startPosition.position - rb.position);
        float distance = direction.magnitude;

        // Normalize the direction vector to get the direction without the distance.
        direction.Normalize();

        // Move the enemy using physics-based velocity.
        rb.velocity = direction * movementSpeed;

        // Check if the enemy has reached the current target position.
        if (distance <= movementSpeed * Time.deltaTime)
        {
            // If the enemy reached the target position, switch the target to the other end.
            movingToEndPosition = !movingToEndPosition;

            // Stop the enemy's movement.
            rb.velocity = Vector2.zero;
        }
    }
}
