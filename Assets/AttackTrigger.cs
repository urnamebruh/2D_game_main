using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public bool attack = false;
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
}
