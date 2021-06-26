using UnityEngine;

public abstract class Movement : IMovement
{
    protected IEmployee _employee;
    protected float speed;
    public abstract void Move();

    protected Movement(float speed)
    {
        this.speed = speed;
    }

    public void Configure(IEmployee employee)
    {
        _employee = employee;
    }
}