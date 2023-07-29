using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    Text scoreText;
    int initialScore = 0, currentScore;

    public int CurrentScore { get; set; }

    private void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    private void Start()
    {
        currentScore = initialScore;
        scoreText.text = currentScore.ToString();
    }

    public void UpdateScore(int addScore)
    {
        CurrentScore += addScore;
        scoreText.text = CurrentScore.ToString();
    }

}
