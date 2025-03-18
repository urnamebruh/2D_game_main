using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dier : MonoBehaviour
{
    public bool die = false;
    public bool main;
    
    bool GameOver = false;

    public GameObject BruteForce;

    public int maxHealth;
    int currentHealth;
    int Damage = 1;
    int Difficulty = 1;
    void Start()
    {
        Damage = 1 * Difficulty;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Main_Takes_Damage");
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            if(main == true)
            {
                Debug.Log("Game Won!!!");
                GameOver = true;
            }
            die = true;
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == BruteForce)
        {
            Debug.Log("Enemy_Hit_Sword");
            TakeDamage(1);
        }
        if(collision.gameObject.CompareTag("Boolet"))
        {
            Debug.Log("Enemy_Hit");
            TakeDamage(1);
        }
    }
}
