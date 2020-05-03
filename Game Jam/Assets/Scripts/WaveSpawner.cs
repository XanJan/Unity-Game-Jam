using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform barrelGuy;
        public int count;
        public float rate;
    }

    public List<Wave> waves;
    private int nextWave = 0;

    public Transform[] spawnPoints; 

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    private TargetScript waterScript;
    public float addWaterAmount;

    public Rigidbody2D rb;
    public Transform startPosition;
    public TextMeshProUGUI scoreVisual;
    public float score = 0;
    public Transform barrelGuy1;

    public Animator animator;

    public Wave wave1;
    public Wave wave2;

    private int AddingCount;
    private float AddingRate;
    private int Round;
    private int test;
    public TextMeshProUGUI wavenumber;
    public int wave;


    void Start()
    {
        AddingCount = 2;
        AddingRate = 2f;
        Round = 1;

        wave1 = new Wave();
        wave1.name = Round.ToString();
        wave1.barrelGuy = barrelGuy1;
        wave1.count = AddingCount;
        wave1.rate = AddingRate;
        waves.Add(wave1);


        waterScript = GameObject.Find("Target").GetComponent<TargetScript>();
        waveCountdown = timeBetweenWaves;

        scoreVisual.text = "Score: " + score.ToString();

        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenceds");
        }
    }

    void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if (!EnemyIsalive()) //Begin a new wave
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }
        if(waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine( SpawnWave (waves[nextWave] ) );
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        wave++;
        AddingCount++;
        AddingRate += 0.25f;
        Round++;

        wave2 = new Wave();
        wave2.name = Round.ToString();
        wave2.barrelGuy = barrelGuy1;
        wave2.count = AddingCount;
        wave2.rate = AddingRate;

        waves.Add(wave2);

        //int RemoveClass = waves.Count;

        //waves.RemoveAt(RemoveClass);

        var gO = Instantiate(animator);
        Destroy(gO, 5f);

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        score += Mathf.Round(waterScript.AmountOfWater);
        scoreVisual.text = "Score: " + score.ToString();

        wavenumber.text = "Wave: " + wave.ToString();

        waterScript.AmountOfWater += addWaterAmount;
        rb.position = startPosition.position;

        //if(nextWave + 1 > waves.Length - 1)
        //{
        //    nextWave = 0;
        //    //Debug.Log("All waves complete, looping...");
        //}
        //else
        //{
        //    nextWave++;
        //}
        nextWave++;
        
    }
    bool EnemyIsalive() // check if there is any enemys alive
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0)
        {
            if(GameObject.FindGameObjectWithTag("Enemy") == null)
            {
            return false;
            }
        }
    
        return true;
    }
    IEnumerator SpawnWave(Wave _wave)
    {
        //Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.barrelGuy);
            yield return new WaitForSeconds(1f/_wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy (Transform _barrelGuy)
    {
       

        //Debug.Log("Spawning Enemy: " + _barrelGuy.name);
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length) ];
        Instantiate(_barrelGuy, _sp.position, _sp.rotation);
        
    }
}
