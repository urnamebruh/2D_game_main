using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject ToSpawn;
    public Transform spawnPoint;
    
    int Spawned_num = 0;
    int Spawn_num = 1;
    int Wave_num = 0;
    int LWave = 0;

    float Timer = 3.0f;
    float Timer2 = 3.0f;
    bool TriggerBool = false;
    bool TimeBool = false;
    bool TimeBool2 = false;
    bool SpawnBool = false;

    void update()
    {
        Debug.Log(Timer);
        Timer -= Time.deltaTime;
        Debug.Log(Timer);
        if(Timer <= 0.0f)
        {
            TimeBool = true;
            Timer = Timer2;
            Debug.Log("TimerWork?");
        }
        if(TriggerBool == true)
        {
            if(TimeBool == false)
            {
                TimeBool = true;
            }
        }
        if(TimeBool == true)
        {
            Debug.Log("TimeBool == true!!!");
            Wave_num -= -1;
            SpawnBool = true;
        }
        if(SpawnBool == true)
        {
            Prespawn();
            SpawnBool = false;
        }
    }
    void Prespawn()
    {
        Debug.Log("Prespawn");
        Spawn_num = Wave_num + 1;
        Spawned_num = 0;
        SpawnV();
    }
    void SpawnV()
    {
        Debug.Log("Spawn");
        if(TimeBool == true)
        {
            Debug.Log("Spawn2");
            if(Spawn_num > Spawned_num)
            {
                Debug.Log("Spawn3");
                Instantiate(ToSpawn, spawnPoint.position, spawnPoint.rotation);
                Spawned_num -= -1;
            }
            else
            {
                Debug.Log("PostSpawn");
                Postspawn();
            }
        }
    }
    void Postspawn()
    {
        TimeBool = false;
        LWave = Wave_num;
        Wave_num -= -1;
        Timer = Timer2;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision.Spawn");
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision.Spawn.Player");
            if(TriggerBool == false)
            {
                Debug.Log("TrigTrue");
                TriggerBool = true;
            }
            else if(TriggerBool == true)
            {
                Debug.Log("TrigFalse");
                TriggerBool = false;
            }
        }
    }
}
