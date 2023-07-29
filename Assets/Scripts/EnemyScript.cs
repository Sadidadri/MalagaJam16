using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] int experience = 10;
    // TODO : Por definir [SerializeField] int damage = 10;
    [SerializeField] int hitPoints = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) getDamaged(1); // TODO : Tiene que reconocer el tipo de "arma" y recoger el valor de da�o
    }

    void getDamaged(int damage)
    {
        hitPoints -= damage;
        if(hitPoints <= 0) OnDeath();
    }


    private void OnDeath()
    {
        //if (experience > 0)
        //    LevelSystem.instance.AddExp(experience);
        gameObject.SetActive(false);
    }
}
