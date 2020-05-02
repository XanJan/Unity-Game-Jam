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
    public float passiveDehydration;

    private Collider2D canDrink;
    private TargetScript waterScript;
    

    void Start()
    {
        waterScript = GameObject.Find("Target").GetComponent<TargetScript>();
        InvokeRepeating("PassiveHydration", 0f, 0.01f);
    }
    void Update()
    {
        canDrink = Physics2D.OverlapCircle(rb.position, radius, whatIsDrinkable);

        if(thirst <= 0f)
        {
            Lose();
        }

        if(Input.GetKeyDown(KeyCode.E) && canDrink != null)
        {
            thirst += drinkAmount;
            waterScript.AmountOfWater -= drinkAmount;
        }
        hydrationBar.fillAmount = thirst / maxHydration;
    }

    public void PassiveHydration()
    {
        thirst -= passiveDehydration;
    }

    public void Lose()
    {
        Destroy(gameObject);
    }
}
