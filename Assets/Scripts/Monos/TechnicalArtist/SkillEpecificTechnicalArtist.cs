using UnityEngine;

public class SkillEpecificTechnicalArtist : Skill
{
    private readonly GeometricsFigureForTheGraphicConfiguration _configure;
    private Vector3 _positionToSpawnVFX;

    public SkillEpecificTechnicalArtist(GeometricsFigureForTheGraphicConfiguration configure, Vector3 positionToSpawnVFX)
    {
        _configure = configure;
        _positionToSpawnVFX = positionToSpawnVFX;
    }

    public SkillEpecificTechnicalArtist(GeometricsFigureForTheGraphicConfiguration configure)
    {
        _configure = configure;
    }

    public void SetPositionToSpawnVFX(Vector3 positionToSpawn)
    {
        _positionToSpawnVFX = positionToSpawn;
    }

    public override void ActionSkill()
    {
        _employee.CreateObject(_configure.GetFigure(), _positionToSpawnVFX);
    }

}
