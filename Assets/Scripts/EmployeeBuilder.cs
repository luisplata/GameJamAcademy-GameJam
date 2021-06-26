using UnityEngine;

public class EmployeeBuilder
{
    private Employee _employee;
    private ISkill _skill;
    private IMovement _movement;
    public EmployeeBuilder(Employee employee)
    {
        _employee = employee;
    }

    public EmployeeBuilder WithSkill(Skill sk)
    {
        _skill = sk;
        return this;
    }
    
    public EmployeeBuilder WithSkillDefault(GameObject skillIns)
    {
        _skill = new SkillEspecific(skillIns);
        return this;
    }

    public EmployeeBuilder WithMovement(Movement mov)
    {
        _movement = mov;
        return this;
    }

    public EmployeeBuilder FromEmployee(Employee employee)
    {
        _employee = employee;
        return this;
    }

    public Employee Build()
    {
        var instantiate = Object.Instantiate(_employee);
        _skill.Configure(instantiate);
        instantiate.SetComponents(_movement, _skill);
        return instantiate;
    }
    
}