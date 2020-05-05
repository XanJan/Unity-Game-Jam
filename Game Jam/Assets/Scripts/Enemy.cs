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
    public bool waterPickup = true;

    public Sprite waterSprite;
   
    public float EnemyTimer;
    private bool colWithWater = false;

    public float enemyPickWaterAmount;




    void Start()
    {
        speed = 3f;
       
        target = GameObject.FindGameObjectWithTag("Water");
        spawnPosition = GameObject.Find("Spawn Point");
        targetScript = GameObject.Find("Target").GetComponent<TargetScript>();
        

    }

    void Update()
    {

        //Debug.Log(target);
        Vector3 relative = transform.InverseTransformPoint(target.transform.position);
        float angle = Mathf.Atan2(relative.y, relative.x ) * Mathf.Rad2Deg - 90;
        transform.Rotate(0, 0, angle);
        dirNormalized = (target.transform.position - transform.position).normalized;
        transform.position = transform.position + dirNormalized * speed * Time.deltaTime;

       float enemyDistance = Vector3.Distance(this.transform.position, target.transform.position);
        if(enemyDistance <= 1 && !waterPickup)
        {
            
            Destroy(gameObject);
        }

        if(colWithWater == true)
        {
            Invoke("PickUpWater", EnemyTimer);
            //EnemyTimer -= 0.004f;
        }
        /*
        if (EnemyTimer <= 0)
        {
            PickUpWater();
            target = FindClosestSpawn();
            speed = 3f;
            GetComponent<SpriteRenderer>().sprite = waterSprite;
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            colWithWater = true;
            speed = 0f;
        }
    }
    void PickUpWater()
    {
        if (waterPickup == true)
        {
            waterPickup = false;
            if(targetScript.AmountOfWater - enemyPickWaterAmount>0f)
                targetScript.AmountOfWater -= enemyPickWaterAmount;
            target = FindClosestSpawn();
            speed = 3f;
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