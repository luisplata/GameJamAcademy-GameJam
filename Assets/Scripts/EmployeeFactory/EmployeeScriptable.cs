using UnityEngine;

[CreateAssetMenu(menuName = "Bellseboss/EmployeeScriptable", fileName = "EmployeeScriptable", order = 0)]
public class EmployeeScriptable : ScriptableObject
{
    [SerializeField] private string _value;

    public string Value => _value;
}