using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLevel1 : MonoBehaviour
{
    [SerializeField]
    GameObject menuOpciones, menuGameplay;
    [SerializeField]
    Slider volumeSlider;
    [SerializeField]
    AudioMixer volumeMixer;

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level1" && Input.GetKeyDown(KeyCode.Escape)) OpenOptions();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenOptions()
    {
        menuGameplay.SetActive(false);
        menuOpciones.SetActive(true);
        Time.timeScale = 0;

    }

    public void ClosePause()
    {
            menuOpciones.SetActive(false); 
            menuGameplay.SetActive(true);

            Time.timeScale = 1;
    }

    public void GotoMainMenu() {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void SetVolume()
    {
        volumeMixer.SetFloat("MusicVol", Mathf.Log10(volumeSlider.value) * 20);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
