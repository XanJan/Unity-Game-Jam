using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkWater : MonoBehaviour
{   
    public Rigidbody2D rb;
    public float thirst;
    public float radius;
    public LayerMask whatIsDrinkable;
    
    private bool canDrink;
    private TargetScript waterScript;
    

    void Start()
    {
        waterScript = GameObject.Find("Target").GetComponent<TargetScript>();
    }

    void Update()
    {
        canDrink = Physics.CheckSphere(new Vector3(rb.position.x, rb.position.y, 0), radius, whatIsDrinkable);

        if(Input.GetKeyDown(KeyCode.E) && canDrink)
        {
            Debug.Log("drink");
            thirst += 10;
            waterScript.AmountOfWater -= 10;
        }
    }
}
