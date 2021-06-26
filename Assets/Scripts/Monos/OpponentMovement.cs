using UnityEngine;

public class OpponentMovement : Movement
{
    private readonly IEmployee _player;
    private readonly float _maxDistanceToClose;

    public OpponentMovement(float speed, IEmployee player, float maxDistanceToClose) : base(speed)
    {
        _player = player;
        _maxDistanceToClose = maxDistanceToClose;
        Debug.Log($"maxDistanceToClose {maxDistanceToClose}");
    }

    public override void Move()
    {
        var diff = _player.GetTargetToOpponents() - _employee.GetPosition();
        if (diff.sqrMagnitude > _maxDistanceToClose)
        {
            _employee.Move(diff.normalized * speed);            
        }
    }
}