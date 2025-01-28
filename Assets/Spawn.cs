using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Tospawn;
    public Transform spawnPoint;

    float spawnInterval = 5.0f;
    float MSI = 2f;
    float intD = 0.1f;

    void start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        Debug.Log("Almost");
        while (true)
        {
            Debug.Log("Working");
            if(Tospawn != null && spawnPoint != null)
            {
                Instantiate(Tospawn, spawnPoint.position, spawnPoint.rotation);
            }
            else
            {
                Debug.LogWarning("Object to spawn or spawn point is not set");
            }

            yield return new WaitForSeconds(spawnInterval);

            spawnInterval = Mathf.Max(MSI, spawnInterval - intD);
        }
    }
}