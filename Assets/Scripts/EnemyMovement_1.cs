using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public SpriteRenderer enemySpriteRenderer;

    public float movementSpeed = 5f; // Adjust this speed to control enemy movement

    private Vector3 destinationPosition;
    private bool isMoving = false;

    void Start(){
        // Assign the SpriteRenderer component of the enemy GameObject to enemySpriteRenderer.
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetDestination(Vector3 destination)
    {
        destinationPosition = destination;
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
        {
            MoveToDestination();
        }
    }

    private void MoveToDestination()
    {
        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destinationPosition, step);

        if (transform.position == destinationPosition)
        {
            isMoving = false;
            gameObject.SetActive(false);
            
        }
    }
}