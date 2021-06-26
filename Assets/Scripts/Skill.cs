public abstract class Skill : ISkill
{
    protected IEmployee _employee;

    public void Configure(IEmployee employee)
    {
        _employee = employee;
    }
    public bool HasPushSkill()
    {
        return _employee.GetInputSkill();
    }
    public abstract void ActionSkill();
}