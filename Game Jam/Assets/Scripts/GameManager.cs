using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public GameObject endScene;
    public GameObject cursor;
    public GameObject pauseMenu;
    public bool GameIsPaused = false;
    public AudioMixer audioMixer;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            cursor.SetActive(false);
            Cursor.visible = true;
            Time.timeScale = 0f;
            gameHasEnded = true;
            endScene.SetActive(true);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Pause()
    {
        GameIsPaused = true;
        cursor.SetActive(false);
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        GameIsPaused = false;
        cursor.SetActive(true);
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void MainMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume_test", volume);
        //Debug.Log(volume);
    }
}
