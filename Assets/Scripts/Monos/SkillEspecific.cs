
using UnityEngine;

public class SkillEspecific : Skill
{
    private GameObject go;
    public SkillEspecific(GameObject gameObjectLocal)
    {
        go = gameObjectLocal;
    }

    public override void ActionSkill()
    {
        var instantiate = Object.Instantiate(go);
        instantiate.transform.position = _employee.GetPosition();
    }

}