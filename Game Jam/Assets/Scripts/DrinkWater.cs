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
            Lose();
        }

        if(Input.GetKeyDown(KeyCode.E) && canDrink != null && thirst < maxHydration)
        {
            if (maxHydration - thirst < drinkAmount)
            {
                var subtract = maxHydration - thirst;
                thirst += subtract;
                waterScript.AmountOfWater -= subtract;
            }
            else
            {
                thirst += drinkAmount;
                waterScript.AmountOfWater -= drinkAmount;
            }
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

    public void Lose()
    {
        Destroy(gameObject);
    }
}
