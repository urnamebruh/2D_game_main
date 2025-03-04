using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HP : MonoBehaviour
{
    public GameObject BruteForce;

    public int maxHealth;
    int currentHealth;
    int Damage = 1;
    int Difficulty = 1;
    public int AV = 1;

    public float alpha = 1f;

    float Timer1 = 0.15f;
    bool TimBool1 = false;
    bool TimBool2 = false;


    public bool yap = false;
    public bool AComms = false;
    public bool Attacking = false;
    public bool Attack = false;
    public bool Tim = true;

    public AttackTrigger AT;
    public Movement PS;

    void Update()
    {
        if(Attack == true)
        {
            attack();
        }
        if(Attacking == true)
        {
            Attack = false;
            AComms = true;
        }
    }

    void Start()
    {
        Damage = 1 * Difficulty;
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
        if(collision.gameObject.CompareTag("Player"))
        {
            Attack = true;
            if(Attacking == true)
            {
                collision.gameObject.GetComponent<Movement>().dam = 1;
                Attacking = false;
            }
        }
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
    void OnTriggerStay2D(Collider2D collision)
    {
    }
    void attack()
    {
        Timer1 -= Time.deltaTime;
        if(Timer1 <= 0.0f)
        {
            Attacking = true;
            TimBool2 = false;
            TimBool1 = false;
            Timer1 = 0.5f;
        }
    }
}