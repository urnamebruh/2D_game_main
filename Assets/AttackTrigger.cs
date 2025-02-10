using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public bool attack = false;
    Bruteforce BR;
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.CompareTag("Player"))
        {
            attack = true;
        }
    }
    void OnTriggerExit2D(Collider2D trigger)
    {
        if(trigger.gameObject.CompareTag("Player"))
        {
            attack = false;
        }
    }
    void update()
    {
        BR = GetComponent<Bruteforce>();
        if(attack == true)
        {
        }
    }
}