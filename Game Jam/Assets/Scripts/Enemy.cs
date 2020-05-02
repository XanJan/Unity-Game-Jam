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
        target = GameObject.Find("Target");
        spawnPosition = GameObject.Find("Spawn Points Enemy/Spawn Point");
        targetScript = GameObject.Find("Target").GetComponent<TargetScript>();
    }

    void Update()
    {
        //dirNormalized = (target.transform.position - transform.position).normalized;
        transform.position = transform.position + dirNormalized * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            PickUpWater();
            waterPickup = false;
            target = spawnPosition;
        }
    }
    void PickUpWater()
    {
        if (waterPickup == true)
        {
            targetScript.AmountOfWater -= 10;
        }
    }
}