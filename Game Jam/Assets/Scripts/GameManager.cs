using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public GameObject endScene;
    public GameObject cursor;
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
}
