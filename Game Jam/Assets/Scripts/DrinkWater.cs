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
    public int drinkAmount;
    public float maxHydration;

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
            thirst += drinkAmount;
            waterScript.AmountOfWater -= drinkAmount;
        }
        hydrationBar.fillAmount = thirst / maxHydration;
    }
}
