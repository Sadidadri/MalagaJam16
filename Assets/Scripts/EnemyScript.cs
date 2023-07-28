using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] int experience = 10;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) OnDeath();
    }

    private void OnDeath()
    {
        if (experience > 0)
            LevelSystem.instance.AddExp(experience);
    }
}
