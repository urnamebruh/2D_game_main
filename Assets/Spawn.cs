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
    float Timer2 = 0.0f;
    bool TriggerBool = false;
    bool TimeBool = false;

    void update()
    {
        Timer2 -= Time.deltaTime;
        if(TimeBool == true)
        {
            Wave_num -= -1;
            Prespawn();
        }
        if(TriggerBool == true)
        {
            Debug.Log("Trigwork");
            if(TimeBool == false)
            {
                Debug.Log("Timework");
                Timer -= Time.deltaTime;
            }
        }
        if(Timer <= 0.0f)
        {
            TimeBool = true;
        }

        if(Wave_num > LWave)
        {
            SpawnV();
        }
    }
    void Prespawn()
    {
        Debug.Log("PreWaveCheck");
        Spawn_num = Wave_num;
        Spawned_num = Spawn_num;
        SpawnV();
    }
    void SpawnV()
    {
        Debug.Log("WaveCheck");
        if(TimeBool == true)
        {
            if(Spawn_num > Spawned_num)
            {
                Instantiate(ToSpawn, spawnPoint.position, spawnPoint.rotation);
                Spawned_num -= -1;
            }
            else
            {
                Postspawn();
            }
        }
    }
    void Postspawn()
    {
        Timer = 3.0f;
        TimeBool = false;
        LWave = Wave_num;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision.Spawn");
        if(collision.gameObject.CompareTag("Player"))
        {
            if(Timer2 <= 0)
            {
                Debug.Log("Collision.Spawn.Player");
                if(TriggerBool == false)
                {
                    Debug.Log("TrigTrue");
                    TriggerBool = true;
                    update();
                }
                else if(TriggerBool == true)
                {
                    Debug.Log("TrigFalse");
                    TriggerBool = false;
                    update();
                }
                Timer2 = 0.1f;
            }
        }
    }
}
