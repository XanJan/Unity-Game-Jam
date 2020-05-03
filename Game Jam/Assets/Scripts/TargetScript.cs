using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TargetScript : MonoBehaviour
{
    public GameObject[] waterSprite;
    public float AmountOfWater;
    [HideInInspector]
    public GameObject waterSpriteActive;
    public float maxVisual;

    public TextMeshProUGUI waterAmountViusual;
    private void Start()
    {
        AmountOfWater = maxVisual/2;
    }


    void Update()
    {
        waterAmountViusual.text = "OASIS: " + Mathf.Round(AmountOfWater).ToString();
        if (AmountOfWater > 0 && AmountOfWater <= maxVisual * 0.2)
        {
            waterSprite[0].SetActive(true);
        }
        else
            waterSprite[0].SetActive(false);
        if (AmountOfWater > maxVisual * 0.2 && AmountOfWater <= maxVisual * 0.3)
        {
            waterSprite[1].SetActive(true);
        }
        else
            waterSprite[1].SetActive(false);
        if (AmountOfWater > maxVisual * 0.3 && AmountOfWater <= maxVisual * 0.4)
        {
            waterSprite[2].SetActive(true);
        }
        else
            waterSprite[2].SetActive(false);
        if (AmountOfWater > maxVisual * 0.4 && AmountOfWater <= maxVisual * 0.5)
        {
            waterSprite[3].SetActive(true);
        }
        else
            waterSprite[3].SetActive(false);
        if (AmountOfWater > maxVisual * 0.5 && AmountOfWater <= maxVisual * 0.6)
        {
            waterSprite[4].SetActive(true);
        }
        else
            waterSprite[4].SetActive(false);
        if (AmountOfWater > maxVisual * 0.6 && AmountOfWater <= maxVisual * 0.7)
        {
            waterSprite[5].SetActive(true);
        }
        else
            waterSprite[5].SetActive(false);
        if (AmountOfWater > maxVisual * 0.7 && AmountOfWater <= maxVisual * 0.8)
        {
            waterSprite[6].SetActive(true);
        }
        else
            waterSprite[6].SetActive(false);
        if (AmountOfWater > maxVisual * 0.8 && AmountOfWater <= maxVisual * 0.9)
        {
            waterSprite[7].SetActive(true);
        }
        else
            waterSprite[7].SetActive(false);
        if (AmountOfWater > maxVisual*0.9 && AmountOfWater <= maxVisual)
        {
            waterSprite[8].SetActive(true);
        }
        else
            waterSprite[8].SetActive(false);
        if (AmountOfWater > maxVisual)
        {
            waterSprite[9].SetActive(true);
        }
        else
            waterSprite[9].SetActive(false);

        for (int i = 0; i < waterSprite.Length; i++)
        {
            if (waterSprite[i].activeSelf)
                waterSpriteActive = waterSprite[i];

        }
    }
}
