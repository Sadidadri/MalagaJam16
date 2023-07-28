using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem instance;

    int level = 0;
    int currentExp;
    int expToNextLevel;

    [SerializeField] float firstLevelExp = 50f;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;

        SetLevel(1);
    }

    void SetLevel(int value)
    {
        this.level = value;
        currentExp = currentExp - expToNextLevel;
        expToNextLevel = (int)(firstLevelExp * Mathf.Pow(level + 1, 2) - (5 * (level + 1)));
    }

    public bool AddExp(int expToAdd)
    {
        currentExp += expToAdd;

        if(currentExp >= expToNextLevel)
        {
            SetLevel(level + 1);
            Debug.Log("Level up!");
            return true;
        }

        //Update UI
        return false;
    }
}