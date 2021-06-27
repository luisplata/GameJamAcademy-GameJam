using UnityEngine;

public class SkillEpecificTechnicalArtist : Skill
{
    private readonly GeometricsFigureForTheGraphicConfiguration _configure;

    public SkillEpecificTechnicalArtist(GeometricsFigureForTheGraphicConfiguration configure)
    {
        _configure = configure;
    }

    public override void ActionSkill()
    {
        _employee.CreateObject(_configure.GetFigure());
    }

}
