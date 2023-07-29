
using UnityEngine;
using UnityEngine.UI;

public class LevelingSystem : MonoBehaviour
{
    [SerializeField] Text levelText;

    [SerializeField] Slider expSlider;
    int level = 0;
    int currentExp;
    int expToNextLevel;

    [SerializeField] float firstLevelExp = 50f;

    private void Start()
    {
        expSlider.value = 0f;
        SetLevel(1);
    }

    void SetLevel(int value)
    {
        this.level = value;
        currentExp = currentExp - expToNextLevel;
        expToNextLevel = (int)(firstLevelExp + Mathf.Pow(level + 1, 2) - (5 * (level + 1)));
        updateLevelUI();
    }

    public bool AddExp(int expToAdd)
    {
        currentExp += expToAdd;

        if(currentExp >= expToNextLevel)
        {
            SetLevel(level + 1);
            return true;
        }

        Debug.Log("Current: " + currentExp + " " + expToNextLevel);
        updateLevelUI();

        return false;
    }
    void updateLevelUI()
    {
        expSlider.value = (float) currentExp / expToNextLevel;
        levelText.text = this.level.ToString();
    }
}
