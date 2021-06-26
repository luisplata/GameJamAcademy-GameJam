using UnityEngine;

public interface IEmployee
{
    void Move(Vector3 input);
    float GetHorizontal();
    float GetVertical();
    bool GetInputSkill();
    Vector3 GetPosition();
}