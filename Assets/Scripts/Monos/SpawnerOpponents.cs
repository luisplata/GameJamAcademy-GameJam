using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerOpponents : MonoBehaviour
{
    [SerializeField] private List<float> timeToSpawnInSeconds, timeToSpawnAliInSeconds;
    [SerializeField] private List<GameObject> pointsToSpawn;
    [SerializeField] private EmployeesConfiguration configuration;
    [SerializeField] private float speedPlayer;
    [SerializeField] private GameObject skillInstantiate, pointToSpawn;
    [SerializeField] private EmployeeScriptable model;
    [SerializeField] private float maxDistance;

    private float startToCount, startToCountAli;
    private int indexToCount, indexToCountAli;
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
        if (indexToCount >= timeToSpawnInSeconds.Count || indexToCountAli >= timeToSpawnAliInSeconds.Count)
        {
            return;
        }
        if (isStartToCount)
        {
            startToCount += Time.deltaTime;
            startToCountAli += Time.deltaTime;
        }
        else
        {
            startToCount = 0;
            startToCountAli = 0;
            indexToCount = 0;
            indexToCountAli = 0;
            return;
        }
        
        if (startToCount > timeToSpawnInSeconds[indexToCount])
        {
            CreateOpponent();
        }
        
        if (startToCountAli > timeToSpawnAliInSeconds[indexToCountAli])
        {
            CreateAli();
        }
    }

    private void CreateAli()
    {
        var employeeBuilder = _factory.Create(model);
        var mov = new AliMovementidle(speedPlayer);
        var opponent = employeeBuilder.WithMovement(mov).WithSkill(new SkillEspecific(new GameObject())).Build();
        opponent.transform.position = pointToSpawn.transform.position;
        //changed color to the alis
        //changed to blue
        opponent.tag = "Ali";
        opponent.name = "Ali";
        indexToCountAli++;
    }

    private void CreateOpponent()
    {
        var employeeBuilder = _factory.Create(model);
        var mov = new OpponentMovement(speedPlayer, _installer.GetPlayer(), (maxDistance + indexToCount) * 40);
        var opponent = employeeBuilder.WithMovement(mov).WithSkill(new SkillEspecific(new GameObject())).Build();
        //changed color to the opponents
        //changed to Red
        opponent.transform.position = pointToSpawn.transform.position;
        opponent.tag = "Opponent";
        opponent.name = "Opponent";
        indexToCount++;
    }

    public void Configure(Installer installer)
    {
        isStartToCount = true;
        _installer = installer;
    }
}