using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkWater : MonoBehaviour
{   
    public Rigidbody2D rb;
    public float thirst;
    public float radius;
    public LayerMask whatIsDrinkable;
    public Image hydrationBar;
    public float drinkAmount;
    public float maxHydration;
    public float passiveDehydration;
    public float activeDehydration;

    private Collider2D canDrink;
    private TargetScript waterScript;
    private Movement movementScript;
    

    void Start()
    {
        waterScript = GameObject.Find("Target").GetComponent<TargetScript>();
        movementScript = GameObject.Find("Player").GetComponent<Movement>();
        InvokeRepeating("PassiveHydration", 0f, 0.01f);
        InvokeRepeating("ActiveHydration", 0f, 0.01f);
    }
    void Update()
    {
        canDrink = Physics2D.OverlapCircle(rb.position, radius, whatIsDrinkable);

        if(thirst <= 0f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if(Input.GetKeyDown(KeyCode.E) && canDrink != null && thirst < maxHydration)
        {
            var currentThirst = thirst;
            if(waterScript.AmountOfWater > 0f)
                
                if (maxHydration - currentThirst < drinkAmount)
                {
                    if (waterScript.AmountOfWater < drinkAmount)
                    {
                        if(waterScript.AmountOfWater > maxHydration - currentThirst)
                        {
                            waterScript.AmountOfWater -= maxHydration - currentThirst;
                            currentThirst += maxHydration - currentThirst;
                        }
                        else if(waterScript.AmountOfWater < maxHydration - currentThirst)
                        {
                            currentThirst += waterScript.AmountOfWater;
                            waterScript.AmountOfWater -= waterScript.AmountOfWater;
                        }
                    }
                    else
                    {
                        var subtract = maxHydration - currentThirst;
                        currentThirst += subtract;
                        waterScript.AmountOfWater -= subtract;
                    }
                }
                else
                {
                    if (waterScript.AmountOfWater < drinkAmount)
                    {
                        currentThirst += waterScript.AmountOfWater;
                        waterScript.AmountOfWater -= waterScript.AmountOfWater;
                    }
                    else
                    {
                        currentThirst += drinkAmount;
                        waterScript.AmountOfWater -= drinkAmount;
                    }

                }
            
            thirst = currentThirst;
        }
        hydrationBar.fillAmount = thirst / maxHydration;
    }

    public void PassiveHydration()
    {
        thirst -= passiveDehydration;
    }

    public void ActiveHydration()
    {
        if (movementScript.movement.magnitude > 0f)
        {
            thirst -= activeDehydration;
        }
    }
}
