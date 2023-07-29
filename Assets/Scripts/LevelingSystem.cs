using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelingSystem : MonoBehaviour
{
    Slider expSlider;

    int level = 0;
    int currentExp;
    int expToNextLevel;

    [SerializeField] float firstLevelExp = 50f;

    private void Awake()
    {
        expSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        expSlider.value = 0f;
        SetLevel(1);
    }

    void SetLevel(int value)
    {
        this.level = value;
        currentExp = currentExp - expToNextLevel;
        expToNextLevel = (int)(firstLevelExp * Mathf.Pow(level + 1, 2) - (5 * (level + 1)));
        //updateLevelUI();
    }

    public bool AddExp(int expToAdd)
    {
        currentExp += expToAdd;

        if(currentExp >= expToNextLevel)
        {
            SetLevel(level + 1);
            return true;
        }

        expSlider.value = (float) Mathf.Round(currentExp / expToNextLevel);

        return false;
    }

//    void updateLevelUI()
}
