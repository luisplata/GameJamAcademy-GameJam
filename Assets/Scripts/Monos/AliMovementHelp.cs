using UnityEngine;

public class AliMovementHelp : Movement
{
    public AliMovementHelp(float speed) : base(speed)
    {
    }

    public override void Move()
    {
        _employee.Move(Vector3.right);
    }
}