using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    bool ABC = false;
    public GameObject Goat;
    public Transform Rotation;
    public Transform SpawnPoint;


    void Update()
    {
        Debug.Log("W2");
        if(ABC == true)
        {
            SpawnPoint = transform;
            Debug.Log("W3");
            GameObject enemy = Instantiate(Goat, SpawnPoint.position, SpawnPoint.rotation);
            Destroy(gameObject);
            ABC = false;
        }
    }
    public void OnParticleCollision(GameObject other)
    {
        ABC = true;
        Debug.Log("W1");
    }
}