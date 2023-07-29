using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public SpriteRenderer enemySpriteRenderer;

    public float movementSpeed = 5f; // Adjust this speed to control enemy movement
    public int monster_type = 1;
    //1 is for normal person, 2 for police and 3 for military

    private Vector3 destinationPosition;
    private bool isMoving = false;
    GameObject playerObject;

    void OnEnable(){
        // Find the player's GameObject by its tag (You should assign the "Player" tag to your player GameObject)
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

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

        if(monster_type == 1){
            if (transform.position == destinationPosition)
                    {
                        isMoving = false;
                        gameObject.SetActive(false);
                        
                    }
        }else{
            Debug.Log(playerObject);
            if(playerObject != null){
                SetDestination(playerObject.transform.position);
            }
        }
       
    }
}