using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript2 : MonoBehaviour
{
    public GameObject controls;
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

    public void BackToMainMenu()
    {
        controls.SetActive(false);
    }
}
