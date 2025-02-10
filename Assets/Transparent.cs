using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparent : MonoBehaviour
{
    public Material myMaterial;

    [Range(0f,1f)]

    public float alpha = 1f;
    public GameObject BruteForce;


    Enemy_HP EH;
    MeshRenderer meshRenderer;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        EH = GetComponent<Enemy_HP>();
        alpha = EH.alpha;
        if(alpha <= 0f)
        {
            alpha = 0f;
        }
        if(alpha >= 1f)
        {
            alpha = 1f;
        }
        myMaterial = GetComponent<MeshRenderer>().material;
        Color transparentColor = new Color(myMaterial.color.r, myMaterial.color.g, myMaterial.color.b, alpha);
    }
}
