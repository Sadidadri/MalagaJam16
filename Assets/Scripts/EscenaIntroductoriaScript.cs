using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class EscenaIntroductoriaScript : MonoBehaviour
{
    public TMP_Text[] textMeshes; // Array to hold the TMP Text objects
    public float fadeInDuration = 1.5f;
    public float fadeOutDuration = 1.5f;
    public float delayBetweenTexts = 1.5f;
    private Color originalColor;
    private Color transparentColor;
    private float timer;
    private int currentTextIndex = 0;
    

    void Start()
    {
        // Set the original color and transparent color for each TMP Text
        foreach (var textMesh in textMeshes)
        {
            originalColor = textMesh.color;
            transparentColor = originalColor;
            transparentColor.a = 0f;
            textMesh.color = transparentColor;
        }

        // Start the fade-in for the first text
        StartCoroutine(StartFadeIn());
    }

    private IEnumerator StartFadeIn()
    {
        // Fade in the current text
        while (timer < fadeInDuration)
        {
            timer += Time.deltaTime;
            float alpha = timer / fadeInDuration;
            textMeshes[currentTextIndex].color = Color.Lerp(transparentColor, originalColor, alpha);
            yield return null;
        }

        // Ensure the text is fully visible at the end of the fade-in
        textMeshes[currentTextIndex].color = originalColor;

        // Wait for a delay before starting the fade-out
        yield return new WaitForSeconds(delayBetweenTexts);

        // Start the fade-out for the current text
        StartCoroutine(StartFadeOut());
    }

    private IEnumerator StartFadeOut()
    {
        // Fade out the current text
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            float alpha = timer / fadeOutDuration;
            textMeshes[currentTextIndex].color = Color.Lerp(transparentColor, originalColor, alpha);
            yield return null;
        }

        // Ensure the text is fully transparent at the end of the fade-out
        textMeshes[currentTextIndex].color = transparentColor;

      
        if(currentTextIndex == 1){
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        // Move to the next text
        currentTextIndex = (currentTextIndex + 1) % textMeshes.Length;
        // Start the fade-in for the next text
        StartCoroutine(StartFadeIn());
    }
}