public class SkillForGraphic : Skill
{
    private readonly GeometricsFigureForTheGraphicConfiguration _configure;
    private readonly float _force;

    public SkillForGraphic(GeometricsFigureForTheGraphicConfiguration configure, float force)
    {
        _configure = configure;
        _force = force;
    }

    public override void ActionSkill()
    {
        _employee.CreateObject(_configure.GetFigure(), _force);
    }
}