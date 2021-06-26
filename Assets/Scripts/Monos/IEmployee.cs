using System.Collections.Generic;
using UnityEngine;

public interface IEmployee
{
    void Move(Vector3 input);
    float GetHorizontal();
    float GetVertical();
    bool GetInputSkill();
    Vector3 GetPosition();
    Vector3 GetObjective();
    Vector3 GetTargetToOpponents();
    List<Employee> GetListToOtherOpponents();
    void CreateObject(GameObject figure, float force);
    void CreateObject(GameObject getFigure, Vector3 positionToSpawnVFX);
}