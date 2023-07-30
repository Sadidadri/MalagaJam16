using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField]
    GameObject menuPrincipal, menuOpciones;
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

    public void OpenOptions()
    {
        menuPrincipal.SetActive(false);
        menuOpciones.SetActive(true);
    }

    public void OpenMainMenu()
    {
        menuOpciones.SetActive(false);
        menuPrincipal.SetActive(true);
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
