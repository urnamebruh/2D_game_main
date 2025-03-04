using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparent : MonoBehaviour
{
    public Material myMaterial;

    [Range(0f,1f)]

    public float alpha = 1f;

    public AttackTrigger AT;
    
    // Update is called once per frame
    void Update()
    {
        Debug.Log(AT.Attack);
        // Colour Controller
        if(alpha >= 0.5f)
        {
            alpha -= Time.deltaTime/100;
        }
        if(AT.Attack == true)
        {
            if(alpha <= 0.25f)
            {
                alpha -= -Time.deltaTime*4;
            }
        }
        
        // Machine
        if(alpha >= 1f)
        {
            alpha = 1f;
        }
        myMaterial.color = new Color(myMaterial.color.r, myMaterial.color.g, myMaterial.color.b, alpha);
    }
}
