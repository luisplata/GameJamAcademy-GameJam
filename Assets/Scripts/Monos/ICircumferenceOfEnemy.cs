using JetBrains.Annotations;
using UnityEngine;

public interface ICircumferenceOfEnemy
{
    void Rotate();
    void Configure(IEmployee employee);
    Vector3 GetPointToOpponents();
}