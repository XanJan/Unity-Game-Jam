using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField]
    GameObject target;

    [SerializeField]
    float speed;

    Vector3 dirNormalized;
    private TargetScript targetScript;


    void Start()
    {
        targetScript = GameObject.Find("Target").GetComponent<TargetScript>();
    }

    void Update()
    {
       dirNormalized = (target.transform.position - transform.position).normalized;
       if (Vector3.Distance(target.transform.position, transform.position) <= 1)
       {
            //enabled = false;  // causes that Update() of this MonoBehavior is not called anymore (until enabled is set back to true)
         speed = 0f;
         Debug.Log("Fienden är vid vattnet");                // Do whatever you want when the object is close to its target here
       }
       else
       {
           transform.position = transform.position + dirNormalized * speed * Time.deltaTime;
       }
    }

    void PickUpWater()
    {
        
    }
    
}
