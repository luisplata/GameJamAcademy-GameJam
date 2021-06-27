using System.Collections.Generic;
using UnityEngine;

public class SpawnerOpponents : MonoBehaviour
{
    [SerializeField] private List<float> timeToSpawnInSeconds, timeToSpawnAliInSeconds;
    [SerializeField] private List<GameObject> pointsToSpawn;
    [SerializeField] private Transform pointsToSpawnAli;
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
        if (indexToCountAli < timeToSpawnAliInSeconds.Count)
        {
            if (startToCountAli > timeToSpawnAliInSeconds[indexToCountAli])
            {
                CreateAli();
            }
        }

        if (indexToCount < timeToSpawnInSeconds.Count)
        {
            if (startToCount > timeToSpawnInSeconds[indexToCount])
            {
                CreateOpponent();
            }
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
        Skill skillEpecific = null;
        if (_installer.GetPlayer().GetId() == _installer.GetArtistId().Value)
        {
            skillEpecific = new SkillEpecificTechnicalArtist(Instantiate(_installer.GetTechnicalArtisConfig()));
            model = _installer.GetTechnicalArtistId();
        }else if (_installer.GetPlayer().GetId() == _installer.GetTechnicalArtistId().Value)
        {
            skillEpecific = new SkillForGraphic(Instantiate(_installer.GetGraphicConfiguration()), _installer.GetForce());
            model = _installer.GetArtistId();
        }
        var employeeBuilder = _factory.Create(model);
        var mov = new OpponentMovement(speedPlayer, _installer.GetPlayer(), (maxDistance + indexToCount) * 40);
        var opponent = employeeBuilder.WithMovement(mov).WithSkill(skillEpecific).Build();
        //changed color to the opponents
        //changed to Red
        var posintToSpawn = pointsToSpawn[Random.Range(0,pointsToSpawn.Count)].transform.position;
        opponent.transform.position = posintToSpawn;
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