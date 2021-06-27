public class SkillForTheAli : Skill
{
    private readonly ISkill _skill;

    public SkillForTheAli(ISkill skill)
    {
        _skill = skill;
    }

    public override void ActionSkill()
    {
        _employee.StartToSkill();
        _skill.ActionSkill();
    }
}