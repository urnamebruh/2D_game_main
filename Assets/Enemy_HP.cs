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
    int AV;

    AttackTrigger AT;

    float Timer1 = 0.15f;
    bool TimBool1 = false;
    float Timer2 = 0.5f;
    bool TimBool2 = false;

    public bool Comms = false;
    public bool Attacking = false;

    void Update()
    {
        AT = GetComponent<AttackTrigger>();
        if(AT.attack == true)
        {
            Attack();
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
        if(collision.gameObject == BruteForce)
        {
            Debug.Log("Enemy_Hit_Sword");
            TakeDamage(1);
        }
        else if(collision.gameObject.CompareTag("Boolet"))
        {
            Debug.Log("Enemy_Hit");
            TakeDamage(1);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(Attacking == true)
            {
                AV = Damage;
                Comms = true;
            }
        }
    }
    void Attack()
    {
        AT = GetComponent<AttackTrigger>();
        if(TimBool2 == false)
        {
            Timer2 = 0.35f;
        }
        if(TimBool2 == true)
        {
            Timer1 = 0.15f;
            Timer2 -= Time.deltaTime;
        }
        if(TimBool1 == true)
        {
            Timer1 -= Time.deltaTime;
        }
        if(Timer1 <= 0.0f)
        {
            Attacking = true;
            TimBool2 = false;
            TimBool1 = false;
        }
        if(Timer2 <= 0.0f)
        {
            TimBool2 = true;
        }
    }
}
