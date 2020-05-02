using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetScript : MonoBehaviour
{
    public GameObject[] waterSprite;
    public float AmountOfWater;
    [HideInInspector]
    public GameObject waterSpriteActive;


    void Update()
    {
        if (AmountOfWater > 0 && AmountOfWater <= 20)
        {
            waterSprite[0].SetActive(true);
        }
        else
            waterSprite[0].SetActive(false);
        if (AmountOfWater > 20 && AmountOfWater <= 30)
        {
            waterSprite[1].SetActive(true);
        }
        else
            waterSprite[1].SetActive(false);
        if (AmountOfWater > 30 && AmountOfWater <= 40)
        {
            waterSprite[2].SetActive(true);
        }
        else
            waterSprite[2].SetActive(false);
        if (AmountOfWater > 40 && AmountOfWater <= 50)
        {
            waterSprite[3].SetActive(true);
        }
        else
            waterSprite[3].SetActive(false);
        if (AmountOfWater > 50 && AmountOfWater <= 60)
        {
            waterSprite[4].SetActive(true);
        }
        else
            waterSprite[4].SetActive(false);
        if (AmountOfWater > 60) //&& AmountOfWater <= 70)
        {
            waterSprite[5].SetActive(true);
        }
        else
            waterSprite[5].SetActive(false);

        for (int i = 0; i < waterSprite.Length; i++)
        {
            if (waterSprite[i].activeSelf)
                waterSpriteActive = waterSprite[i];

        }
    }
}
