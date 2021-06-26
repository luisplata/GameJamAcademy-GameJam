using UnityEngine;

public class OpponentMovement : Movement
{
    public OpponentMovement(float speed) : base(speed)
    {
    }

    public override void Move()
    {
        _employee.Move(Vector3.forward);
    }
}