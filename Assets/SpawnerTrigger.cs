using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour
{
    public GameObject Spawner;

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.CompareTag("Player"))
        {
            Debug.Log("check1");
            SetSpawner();
        }
    }
    void OnTriggerExit2D(Collider2D trigger)
    {
        if(trigger.gameObject.CompareTag("Player"))
        {
            Debug.Log("check2");
            UnsetSpawner();
        }
    }
    // Set and Unset Spawner
    public void SetSpawner()
    {
        Spawner.SetActive(true);
    }
    public void UnsetSpawner()
    {
        Spawner.SetActive(false);
    }
}
