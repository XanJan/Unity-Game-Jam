using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private GameObject enemy;
    [SerializeField]
    private float timer;

    void Start()
    {
        enemy = GameObject.Find("Enemy");
        timer = 2;
    }

    
    void Update()
    {
        timer -= Time.deltaTime;
        Spawn();
    }

    void Spawn()
    {
        if (timer <= 0)
        {
            Instantiate(enemy, transform.position, transform.rotation);
            timer = 2;
        }
        
    }
}
