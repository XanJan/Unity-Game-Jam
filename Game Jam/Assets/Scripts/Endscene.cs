using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Endscene : MonoBehaviour
{
    public TextMeshProUGUI endScore;
    private WaveSpawner waveSpawnerScript;
    private void Start()
    {
        waveSpawnerScript = GameObject.Find("Game Manager").GetComponent<WaveSpawner>();
    }
    private void Update()
    {
        endScore.text = "YOUR SCORE: " + waveSpawnerScript.score.ToString();
    }
}
