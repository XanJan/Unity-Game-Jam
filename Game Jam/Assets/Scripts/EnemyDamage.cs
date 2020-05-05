
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    public float health = 3f;
    public GameObject barrel;
    private Enemy enemyScript;
    public AudioSource hitEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    void Start()
    {
        enemyScript = gameObject.GetComponent<Enemy>();
    }

    public void TakeDamage(float amount)
    {
        hitEffect.Play();
        health -= amount;
        healthBar.fillAmount = health / 3;
        if (health <= 0f)
        {
            if (!enemyScript.waterPickup)
            {
                
                GameObject gO =Instantiate(barrel, transform.position, transform.rotation);
                Barrel barellScript = gO.GetComponent<Barrel>();
                barellScript.barrellAmount = enemyScript.amountPickedUp;
                Die();
            }
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

