using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{

    public Text scoreTxT;
    [SerializeField] int enemy_defeated_xp = 10;
    // TODO : Por definir [SerializeField] int damage = 10;
    [SerializeField] int hitPoints = 3;


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
        //if (enemy_defeated_xp > 0)
        //    LevelSystem.instance.AddExp(experience);
        
        scoreTxT.text = (int.Parse(scoreTxT.text) + enemy_defeated_xp).ToString();
        gameObject.SetActive(false);
    }
}
