using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathL : MonoBehaviour
{
    public ui_Man_3 ui_Man_3;
    public dier Dier;
    void Update()
    {
        if(Dier.die == true)
        {
            ui_Man_3.death = true;
            Destroy(this.gameObject);
        }
    }
}
