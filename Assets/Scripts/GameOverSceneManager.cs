using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class GameOverSceneManager : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1.5f;

    private float currentTime = 0 ;
    [SerializeField] Text scoreText;
    
    private void Start()
    {
        currentTime = 0;
        scoreText.text = PlayerPrefs.GetFloat("Score").ToString();
        StartCoroutine(FadeIn());
    }

    void Update(){
        currentTime += Time.deltaTime;
        if (currentTime > 5){
            RestartGame();
        }
    }

    IEnumerator FadeIn()
    {
        fadeImage.color = Color.black;

        float t = 1f;
        while (t > 0f)
        {
            t -= Time.deltaTime / fadeDuration;
            fadeImage.color = new Color(0f, 0f, 0f, t);
            yield return null;
        }

        fadeImage.color = Color.clear;
    }

    public void RestartGame()
    {
        StartCoroutine(FadeOutAndRestart());
    }

    IEnumerator FadeOutAndRestart()
    {
        fadeImage.color = Color.clear;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / fadeDuration;
            fadeImage.color = new Color(0f, 0f, 0f, t);
            yield return null;
        }

        fadeImage.color = Color.black;
        SceneManager.LoadScene("MenuPrincipal"); 
    }
}