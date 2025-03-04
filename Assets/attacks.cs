using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacks : MonoBehaviour
{
    Movement PS;
    Enemy_HP EH;
    void OnTriggerEnter2D(Collider2D trigger)
    {
        EH = GetComponent<Enemy_HP>();
        if(EH.AComms == true)
        {
            Debug.Log("wprk");
            if(trigger.gameObject.CompareTag("Player"))
            {
                PS = GetComponent<Movement>();
                PS.dam = EH.AV;
                EH.AComms = false;
            }
        }
    }
}
