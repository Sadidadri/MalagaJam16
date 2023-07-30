using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField]
    GameObject menuPrincipal, menuOpciones, menuGameplay;
    [SerializeField]
    Slider volumeSlider;
    [SerializeField]
    AudioMixer volumeMixer;

    private void Awake()
    {
        OpenMainMenu();
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level1" && Input.GetKeyDown(KeyCode.Escape)) OpenOptions();
    }

    private void Start()
    {
        if (menuPrincipal != null && menuOpciones != null && SceneManager.GetActiveScene().buildIndex == 0)
        {
            volumeSlider.value = .4f;
            SetVolume();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public bool OpenOptions()
    {
        if (menuPrincipal != null && menuOpciones != null && SceneManager.GetActiveScene().buildIndex == 0)
        {
            menuPrincipal.SetActive(false);
            menuOpciones.SetActive(true);
            return true;
        }

        if(menuGameplay != null && menuOpciones != null && SceneManager.GetActiveScene().name == "Level1")
        {
            menuGameplay.SetActive(false);
            menuOpciones.SetActive(true);
            Time.timeScale = 0;
            return true;
        }

        return false;
    }

    public bool ClosePause()
    {
        if (menuGameplay != null && menuOpciones != null && SceneManager.GetActiveScene().name == "Level1")
        {

            menuOpciones.SetActive(false); 
            menuGameplay.SetActive(true);

            Time.timeScale = 1;
            return true;
        }

        return false;
    }

    public bool OpenMainMenu()
    {
        if(menuPrincipal != null && menuOpciones != null && SceneManager.GetActiveScene().buildIndex == 0)
        {
            menuOpciones.SetActive(false);
            menuPrincipal.SetActive(true);

            return true;
        }

        return false;
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
