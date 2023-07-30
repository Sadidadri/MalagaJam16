using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLogic : MonoBehaviour
{
    public int maxLives = 5;
    private int currentLives;
    public float invulnerabilityTime = 2f; // Adjust this value to set the duration of invulnerability.
    private bool isInvulnerable = false;
    private float invulnerabilityTimer = 0f;

    public SpriteRenderer playerSpriteRenderer; // Reference to the player's SpriteRenderer component.
    private int numberOfBlinks = 10;

    public GameObject[] livesUI;

    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives;

         // Assign the SpriteRenderer component of the player GameObject to playerSpriteRenderer.
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    

    // Update is called once per frame
    void Update()
    {
         if (isInvulnerable)
        {
            invulnerabilityTimer -= Time.deltaTime;

            float blinkRate = invulnerabilityTime / numberOfBlinks;

            if (invulnerabilityTimer <= blinkRate * (numberOfBlinks - 1))
            {
                // Toggle the visibility of the player's sprite.
                playerSpriteRenderer.enabled = !playerSpriteRenderer.enabled;
            }

            if (invulnerabilityTimer <= 0f)
            {
                isInvulnerable = false;
            }
        } else
        {
            // Reset the player's sprite visibility when not invulnerable.
            playerSpriteRenderer.enabled = true;
        }
    }

     private void OnTriggerEnter2D(Collider2D  collider)
    {
        if (!isInvulnerable && collider.gameObject.CompareTag("Enemy"))
        {
            LoseLife();
        }
    }

    private void LoseLife()
    {
        livesUI[currentLives - 1].SetActive(false);
        currentLives--;

        Debug.Log("Your current number of lives are: "+currentLives);

        if (currentLives <= 0)
        {
            // Game Over: Load the Game Over scene
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            // Is hitted, change color and give vulnerability for 2 seconds
             ActivateInvulnerability();
        }
    }

     private void ActivateInvulnerability()
    {
        isInvulnerable = true;
        invulnerabilityTimer = invulnerabilityTime;
        
        StartCoroutine(BlinkSprite());
    }

     private IEnumerator BlinkSprite()
    {
        // Store the original visibility state of the sprite before blinking.
        bool originalVisibility = playerSpriteRenderer.enabled;

        // Calculate the blinking rate by dividing invulnerabilityTime by the number of blinks.
        float blinkRate = invulnerabilityTime / numberOfBlinks;

        // Perform the blinking effect for the duration of the invulnerability time.
        for (int i = 0; i < numberOfBlinks; i++)
        {
            // Toggle the visibility of the player's sprite.
            playerSpriteRenderer.enabled = !playerSpriteRenderer.enabled;

            // Wait for the blinkRate duration before toggling again.
            yield return new WaitForSeconds(blinkRate);
        }

        // Ensure that the player's sprite is visible at the end of the blinking effect.
        playerSpriteRenderer.enabled = originalVisibility;

        // Invulnerability period is over.
        isInvulnerable = false;
    }
}
