using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    private static int DEFAULT_HIT_POINTS = 3;
    public Text scoreTxT;
    [SerializeField] int enemy_defeated_xp = 10;
    public ScoreUI scoreUI;

    [SerializeField] int enemyExp = 10;
    [SerializeField] int enemyScore = 1;

    [SerializeField] ScoreUI scoreUI;
    [SerializeField] LevelingSystem levelingSystem;

    // TODO : Por definir [SerializeField] int damage = 10;
    [SerializeField] int hitPoints = DEFAULT_HIT_POINTS;

    public SpriteRenderer enemySpriteRenderer; // Reference to the enemy's SpriteRenderer component.
    private int numberOfBlinks = 4;

    void OnEnable()
    {
         // Assign the SpriteRenderer component of the enemy GameObject to enemySpriteRenderer.
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
        enemySpriteRenderer.enabled = true;
        hitPoints = DEFAULT_HIT_POINTS;
    }

    void OnDisable(){
        StopCoroutine(BlinkSprite());
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) getDamaged(1); // TODO : Tiene que reconocer el tipo de "arma" y recoger el valor de da�o
    }

    void getDamaged(int damage)
    {
        hitPoints -= damage;
        StartCoroutine(BlinkSprite());
        if(hitPoints <= 0) OnDeath();
    
    }


    private void OnDeath()
    {
        //if (enemy_defeated_xp > 0)
        //    LevelSystem.instance.AddExp(experience);
        scoreUI.UpdateScore(enemyScore);
        

        gameObject.SetActive(false);
    }


    private IEnumerator BlinkSprite()
    {
        // Store the original visibility state of the sprite before blinking.
        float blinkRate = 0.1f;

        // Perform the blinking effect for the duration of the invulnerability time.
        for (int i = 0; i < numberOfBlinks; i++)
        {
            // Toggle the visibility of the player's sprite.
            enemySpriteRenderer.enabled = !enemySpriteRenderer.enabled;

            // Wait for the blinkRate duration before toggling again.
            yield return new WaitForSeconds(blinkRate);
        }

        // Ensure that the player's sprite is visible at the end of the blinking effect.
        enemySpriteRenderer.enabled = true;

    }
}
