using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public bool Attack = false;

    public float Difficulty = 1.0f;
    public float Timer = 0f;

    public Enemy_HP EH;
    public Movement PS;

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.CompareTag("Player"))
        {
            if(Timer <= 0)
            {
                EH.AComms = false;
                EH.yap = false;
                Debug.Log("attack_Triggered");
                Timer = 1*Difficulty;
            }
        }
    }

    void OnTriggerStay2D(Collider2D trigger)
    {
        if(trigger.gameObject.CompareTag("Enemy"))
        EH = trigger.gameObject.GetComponent<Enemy_HP>();
    }

    void OnTriggerExit2D(Collider2D trigger)
    {
        if(trigger.gameObject.CompareTag("Player"))
        {
            Attack = false;
        }
    }
    void Update()
    {
        if(Attack == true)
        {
        }
        Timer -= Time.deltaTime;
    }
}