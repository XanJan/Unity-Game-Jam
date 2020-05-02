
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    public float health = 3f;

    [Header("Unity Stuff")]
    public Image healthBar;

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / 3;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

