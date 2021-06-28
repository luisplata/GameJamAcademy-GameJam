using System.Linq;
using UnityEngine;

public class OpponentMovement : Movement
{
    private readonly IEmployee _player;
    private readonly float _maxDistanceToClose;

    public OpponentMovement(float speed, IEmployee player, float maxDistanceToClose) : base(speed)
    {
        _player = player;
        _maxDistanceToClose = maxDistanceToClose;
        //Debug.Log($"maxDistanceToClose {maxDistanceToClose}");
        
    }

    public override void Move()
    {
        /*var diff = _player.GetTargetToOpponents() - _employee.GetPosition();
        var listToOtherOpponents = _employee.GetListToOtherOpponents();
        if (diff.sqrMagnitude < _maxDistanceToClose && listToOtherOpponents.Count > 0)
        {
            diff = Vector3.zero;
            foreach (var opponent in listToOtherOpponents)
            {
                diff += (_employee.GetPosition() - opponent.gameObject.transform.position);
            }
            diff.y = 0;
        }
        _employee.Move(diff.normalized * speed);*/
        _employee.SetPointToGo(_player.GetTargetToOpponents());
    }
}