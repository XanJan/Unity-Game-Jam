using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public GameObject endScene;
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            Time.timeScale = 0f;
            gameHasEnded = true;
            endScene.SetActive(true);
        }
    }
}
