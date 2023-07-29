using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    int timerLimitMinutes = 10;

    Text timeValue;
    float initialTime = 0;
    float currentTime;
    int minutes, seconds, timerLimitSeconds;

    private void Awake()
    {
        timerLimitSeconds = timerLimitMinutes * 60;
        timeValue = GetComponent<Text>();
    }

    private void Start()
    {
        currentTime = initialTime;
        StartCoroutine(TimerCorr());
    }

    IEnumerator TimerCorr()
    {
        do
        {
            currentTime++;
            updateTimerUI();
            yield return new WaitForSeconds(1f);
        } while (currentTime < timerLimitSeconds);
    }
    void updateTimerUI()
    {
        minutes = Mathf.FloorToInt(currentTime / 60);
        seconds = Mathf.FloorToInt(currentTime % 60);

        timeValue.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
