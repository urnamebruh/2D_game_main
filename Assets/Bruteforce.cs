using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bruteforce : MonoBehaviour
{
    AttackTrigger AT;
    public bool attackT = false;

    // Update is called once per frame
    void Update()
    {
        AT = GetComponent<AttackTrigger>();
        attackT = AT.attackT
    }
    void OnTriggerStay2D(Collider2D trigger)
    {
        
    }
}