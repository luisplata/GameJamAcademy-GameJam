using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerOpponents : MonoBehaviour
{
    [SerializeField] private List<float> timeToSpawnInSecons;
    [SerializeField] private EmployeesConfiguration configuration;
    [SerializeField] private float speedPlayer;
    [SerializeField] private GameObject skillInstantiate, pointToSpawn;
    [SerializeField] private string model;
    [SerializeField] private float maxDistance;

    private float startToCount;
    private int indexToCount;
    private EmployeesFactory _factory;
    private int countToEnemys;
    private bool isStartToCount;
    private Installer _installer;

    private void Start()
    {
        _factory = new EmployeesFactory(Instantiate(configuration));
    }

    // Update is called once per frame
    void Update()
    {
        if (indexToCount >= timeToSpawnInSecons.Count)
        {
            return;
        }
        if (isStartToCount)
        {
            startToCount += Time.deltaTime;
        }
        else
        {
            startToCount = 0;
            indexToCount = 0;
            return;
        }
        
        if (startToCount > timeToSpawnInSecons[indexToCount])
        {
            CreateOpponent();
            indexToCount++;
        }
    }

    private void CreateOpponent()
    {
        var employeeBuilder = _factory.Create(model);
        var mov = new OpponentMovement(speedPlayer, _installer.GetPlayer(), (maxDistance + indexToCount) * 10);
        var opponent = employeeBuilder.WithMovement(mov).WithSkillDefault(skillInstantiate).Build();
        opponent.transform.position = pointToSpawn.transform.position;
    }

    public void Configure(Installer installer)
    {
        isStartToCount = true;
        _installer = installer;
    }
}