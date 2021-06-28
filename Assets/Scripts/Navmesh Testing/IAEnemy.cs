using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class IAEnemy : MonoBehaviour
{
    [SerializeField] private Transform playerTest;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Vector3 target;
    [SerializeField] private float maxDistance=1f;

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
