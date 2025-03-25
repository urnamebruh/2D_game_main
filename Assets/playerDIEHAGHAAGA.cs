using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDIEHAGHAAGA : MonoBehaviour
{
    float Timer1 = 1.0f;
    bool TimBool1 = false;
    bool TimerC = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            TimBool1 = true;
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(TimerC == true)
            {
                //add fall later!!!!!!!!!!!!!!!!
            }
        }
    }
    void Update()
    {
        if(TimBool1 == true)
        {
            Timer1 -= Time.deltaTime;
        }
        if(Timer1 >= 0.0f)
        {
            TimBool1 = false;
            TimerC = true;
            Timer1 = 1.0f;
        }
    }
}
