using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    bool ABC = false;
    public GameObject Goat;
    public Transform firePointRotation;
    public Transform bulletSpawnPoint;

    void update()
    {
        if(ABC == true)
        {
            GameObject enemy = Instantiate(Goat, bulletSpawnPoint.position, firePointRotation.rotation);
            Destroy(gameObject);
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        ABC = true;
        Debug.Log("bruh");
    }
}
