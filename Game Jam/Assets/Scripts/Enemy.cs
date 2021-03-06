﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    GameObject target;
    private GameObject spawnPosition;

    [SerializeField]
    float currentspeed;

    Vector3 dirNormalized;
    private TargetScript targetScript;
    public bool waterPickup = true;

    public Sprite waterSprite;
   
    public float EnemyTimer;
    private bool colWithWater = false;

    public float enemyPickWaterAmount;

    public float amountPickedUp;

    private GameObject player;
    public float speedEnemy = 3f;




    void Start()
    {
        currentspeed = speedEnemy;
       
        target = GameObject.FindGameObjectWithTag("Water");
        spawnPosition = GameObject.Find("Spawn Point");
        targetScript = GameObject.Find("Target").GetComponent<TargetScript>();
        player = GameObject.Find("Player");
        

    }

    void Update()
    {

        //Debug.Log(target);
        Vector3 relative = transform.InverseTransformPoint(target.transform.position);
        float angle = Mathf.Atan2(relative.y, relative.x ) * Mathf.Rad2Deg - 90;
        transform.Rotate(0, 0, angle);
        dirNormalized = (target.transform.position - transform.position).normalized;
        transform.position = transform.position + dirNormalized * currentspeed * Time.deltaTime;

       float enemyDistance = Vector3.Distance(this.transform.position, target.transform.position);
        if(enemyDistance <= 1 && !waterPickup)
        {
            
            Destroy(gameObject);
        }

        if(colWithWater == true)
        {
            Invoke("PickUpWater", EnemyTimer);
        }
        if (targetScript.AmountOfWater <= 0f && waterPickup == true)
        {
            CancelInvoke("PickUpWater");
            target = player;
            currentspeed = speedEnemy;
        }
        if (waterPickup == false)
            currentspeed = speedEnemy;

            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            colWithWater = true;
            currentspeed = 0f;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            colWithWater = false;
            currentspeed = speedEnemy;
        }
    }
    void PickUpWater()
    {
        if (waterPickup == true)
        {
            waterPickup = false;
            if (targetScript.AmountOfWater > 0f)
                if (targetScript.AmountOfWater - enemyPickWaterAmount >= 0f)
                {
                    targetScript.AmountOfWater -= enemyPickWaterAmount;
                    amountPickedUp = enemyPickWaterAmount;
                }
                else if (targetScript.AmountOfWater - enemyPickWaterAmount < 0f)
                {
                    amountPickedUp = targetScript.AmountOfWater;
                    targetScript.AmountOfWater -= targetScript.AmountOfWater;
                }

            target = FindClosestSpawn();
            currentspeed = speedEnemy;
            GetComponent<SpriteRenderer>().sprite = waterSprite;
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