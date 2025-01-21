using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AImove : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}
