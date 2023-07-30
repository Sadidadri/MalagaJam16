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

    private void Start()
    {
        volumeSlider.value = .4f;
        SetVolume();
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

    public void SetVolume()
    {
        volumeMixer.SetFloat("MusicVol", Mathf.Log10(volumeSlider.value) * 20);
    } 
}
