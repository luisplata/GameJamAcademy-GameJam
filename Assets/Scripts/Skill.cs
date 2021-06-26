public abstract class Skill : ISkill
{
    protected IEmployee _employee;

    public void Configure(IEmployee employee)
    {
        _employee = employee;
    }
    
    public abstract bool HasPushSkill();
    public abstract void ActionSkill();
}