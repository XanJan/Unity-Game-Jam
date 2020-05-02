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
    private Weapon weaponScript;


    void Start()
    {
        speed = 3f;
        target = GameObject.Find("Target");
        spawnPosition = GameObject.Find("Spawn Points Enemy/Spawn Point");
        weaponScript = GameObject.Find("Player").GetComponent<Weapon>();
        targetScript = GameObject.Find("Target").GetComponent<TargetScript>();
    }

    void Update()
    {
        
       dirNormalized = (target.transform.position - transform.position).normalized;
       if (Vector3.Distance(target.transform.position, transform.position) <= 1)
       {
            //enabled = false;  // causes that Update() of this MonoBehavior is not called anymore (until enabled is set back to true)
         //speed = 0f;
         //Debug.Log("Fienden är vid vattnet");                // Do whatever you want when the object is close to its target here
            PickUpWater();
            waterPickup = false;

            target = spawnPosition;
       }
       else
       {
           transform.position = transform.position + dirNormalized * speed * Time.deltaTime;
       }
     

    }

    void PickUpWater()
    {
        if(waterPickup == true)
        {
            targetScript.AmountOfWater -= 10;
        }
        
    }
    
}
