using UnityEngine;

public class PlayerMovement : Movement
{
    private float _tolerance;
    public override void Move()
    {
        var horizontal = _employee.GetHorizontal();
        var vertical = _employee.GetVertical();
        if (horizontal != 0 || vertical != 0)
        {
            _employee.Move(new Vector3(horizontal, 0, vertical) * speed);
        }
    }

    public PlayerMovement(float speed) : base(speed)
    {
    }
}