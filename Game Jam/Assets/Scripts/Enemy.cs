using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    GameObject target;
    private GameObject spawnPosition;

    [SerializeField]
    float speed;

    Vector3 dirNormalized;
    private TargetScript targetScript;
    private bool waterPickup = true;


    void Start()
    {
        speed = 3f;
        target = GameObject.FindGameObjectWithTag("Water");
        spawnPosition = GameObject.Find("Spawn Point");
        targetScript = GameObject.Find("Target").GetComponent<TargetScript>();


    }

    void Update()
    {
        dirNormalized = (target.transform.position - transform.position).normalized;
        transform.position = transform.position + dirNormalized * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            PickUpWater();
            waterPickup = false;
            target = FindClosestSpawn();
            
            
        }
    }
    void PickUpWater()
    {
        if (waterPickup == true)
        {
            targetScript.AmountOfWater -= 10;
        }
    }

    public GameObject FindClosestSpawn()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Spawn Point");
        GameObject closest = null;

        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach(GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }

        }
        return closest;
    }
}