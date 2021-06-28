using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class IAEnemy : MonoBehaviour
{
    [SerializeField] private Transform playerTest;
    [SerializeField] private NavMeshAgent agent;
    private Vector3 target;

    private void Start()
    {
        target = playerTest.position;
        agent.destination = target;
    }

    void Update()
    {   
            agent.destination = playerTest.position;
    }
}
