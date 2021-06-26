using UnityEngine;

public class CircumferenceOfEnemy : MonoBehaviour, ICircumferenceOfEnemy
{
    [SerializeField] private GameObject pointToObject;
    [SerializeField] private GameObject targetToOpponents;
    [SerializeField] private int multiply;
    private IEmployee _employee;
    private Vector3 randomCircle;

    public void Configure(IEmployee employee)
    {
        _employee = employee;
        randomCircle = Random.insideUnitSphere * multiply;
    }

    public Vector3 GetPointToOpponents()
    {
        return targetToOpponents.transform.position + randomCircle;
    }

    public void Rotate()
    {
        var targetDir = _employee.GetObjective() - _employee.GetPosition();
        var angle = Vector3.Angle(targetDir, -transform.forward);
        pointToObject.transform.eulerAngles = new Vector3(0, angle, 0);
    }
}