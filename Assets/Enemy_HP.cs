using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HP : MonoBehaviour
{

    public int maxHealth;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; 
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Enemy_Takes_Damage");
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Debug.Log("EnemyDeath");
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
