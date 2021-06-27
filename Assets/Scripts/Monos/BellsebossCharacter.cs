using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BellsebossCharacter : MonoBehaviour, IBellsebossCharacter
{
    [SerializeField] private float timeMaxToRespawnFire, timeMinToRespawnFire;
    [SerializeField] private GameObject fireObject;
    [SerializeField] private Transform pointToSpawn;
    
    private LogicToBellseboss logic;

    private void Start()
    {
        logic = new LogicToBellseboss(this);
    }

    private void Update()
    {
        logic.Fire(Time.deltaTime);
    }

    public float GetRandom()
    {
        return Random.Range(timeMinToRespawnFire, timeMaxToRespawnFire);
    }

    public void FireObject()
    {
        var instantiate = Instantiate(fireObject);
        instantiate.transform.position = pointToSpawn.position;
        var fireComponent = instantiate.AddComponent<FireComponent>();
        var findWithTag = GameObject.FindWithTag("Player");
        fireComponent.Configure(findWithTag.transform.position);
    }
}