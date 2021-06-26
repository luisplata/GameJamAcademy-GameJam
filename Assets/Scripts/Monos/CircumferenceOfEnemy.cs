using UnityEngine;

public class CircumferenceOfEnemy : MonoBehaviour, ICircumferenceOfEnemy
{
    [SerializeField] private GameObject pointToObject;
    [SerializeField] private GameObject targetToOpponents;
    private IEmployee _employee;

    public void Configure(IEmployee employee)
    {
        _employee = employee;
    }

    public Vector3 GetPointToOpponents()
    {
        return targetToOpponents.transform.position + Random.insideUnitSphere;
    }

    public void Rotate()
    {
        var targetDir = _employee.GetObjective() - _employee.GetPosition();
        var angle = Vector3.Angle(targetDir, transform.forward);
        pointToObject.transform.eulerAngles = new Vector3(0, angle, 0);
    }
}