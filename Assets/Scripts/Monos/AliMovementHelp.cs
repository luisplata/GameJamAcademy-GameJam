using UnityEngine;

public class AliMovementHelp : Movement
{
    private readonly GameObject _target;

    public AliMovementHelp(float speed, GameObject target) : base(speed)
    {
        _target = target;
    }

    public override void Move()
    {
        var diff = _target.transform.position - _employee.GetPosition();
        _employee.Move(diff * speed);
    }
}