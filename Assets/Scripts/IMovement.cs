using UnityEngine;

public interface IMovement
{
    void Move();
    void Configure(IEmployee employee);
    float GetSpeed();
    bool IsEnemy();
}