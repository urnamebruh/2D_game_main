using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparent : MonoBehaviour
{
    public Material myMaterial;

    [Range(0f,1f)]
    
    float Timer1 = 1.5f;
    public float alpha = 1f;

    public AttackTrigger AT;
    
    // Update is called once per frame
    void Update()
    {
        Timer1 -= Time.deltaTime;
        if(Timer1 <=0)
        {
            alpha = 1f;
            Timer1 = 1.5f;
        }
        alpha -= Time.deltaTime;
        myMaterial.color = new Color(myMaterial.color.r, myMaterial.color.g, myMaterial.color.b, alpha);
    }
}
