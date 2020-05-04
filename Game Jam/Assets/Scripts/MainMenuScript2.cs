using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuScript2 : MonoBehaviour
{
    public GameObject controls;
    public GameObject options;
    public AudioMixer audioMixer;

    private void Start()
    {
        Cursor.visible = true;
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Controls()
    {
        controls.SetActive(true);
    }

    public void Options()
    {
        options.SetActive(true);
    }

    public void BackToMainMenu()
    {
        controls.SetActive(false);
        options.SetActive(false);
    }



    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
