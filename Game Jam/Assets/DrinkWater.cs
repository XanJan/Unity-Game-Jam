using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkWater : MonoBehaviour
{   
    public Rigidbody2D rb;
    public float thirst;
    public float radius;
    public LayerMask whatIsDrinkable;
    
    private Collider2D canDrink;
    private TargetScript waterScript;
    

    void Start()
    {
        waterScript = GameObject.Find("Target").GetComponent<TargetScript>();
    }

    void Update()
    {
        canDrink = Physics2D.OverlapCircle(rb.position, radius, whatIsDrinkable);

        if(Input.GetKeyDown(KeyCode.E) && canDrink != null)
        {
            Debug.Log("drink");
            thirst += 10;
            waterScript.AmountOfWater -= 10;
        }
    }
}
