using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HP : MonoBehaviour
{
    public GameObject BruteForce;
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if(collision.gameObject == BruteForce)
        {
            Debug.Log("Enemy_Hit");
            TakeDamage(1);
        }
        else if(collision.gameObject.CompareTag("Boolet"))
        {
            Debug.Log("Enemy_Hit");
            TakeDamage(1);
        }
    }
}
