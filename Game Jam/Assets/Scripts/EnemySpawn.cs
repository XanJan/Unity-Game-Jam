using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField]
    private float timer;
    

    void Start()
    {          
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
