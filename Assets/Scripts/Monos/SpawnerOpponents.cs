using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerOpponents : MonoBehaviour
{
    [SerializeField] private List<float> timeToSpawnInSecons;
    [SerializeField] private bool isStartToCount;
    [SerializeField] private EmployeesConfiguration configuration;
    [SerializeField] private float speedPlayer;
    [SerializeField] private GameObject skillInstantiate, pointToSpawn;

    private float startToCount;
    private int indexToCount;
    private EmployeesFactory _factory;

    // Update is called once per frame
    void Update()
    {
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
        Debug.Log($"delta {startToCount}");
        if (startToCount > timeToSpawnInSecons[indexToCount])
        {
            CreateOpponent();
            indexToCount++;
        }
    }

    private void CreateOpponent()
    {
        _factory = new EmployeesFactory(Instantiate(configuration));
        //player creating
        var employeeBuilder = _factory.Create("default");
        var mov = new OpponentMovement(speedPlayer);
        var opponent = employeeBuilder.WithMovement(mov).WithSkillDefault(skillInstantiate).Build();
        opponent.transform.position = pointToSpawn.transform.position;
    }
}