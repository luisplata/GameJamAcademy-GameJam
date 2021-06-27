using UnityEngine;

public class CircumferenceOfEnemy : MonoBehaviour, ICircumferenceOfEnemy
{
    [SerializeField] private GameObject pointToObject;
    [SerializeField] private GameObject targetToOpponents;
    [SerializeField] private int multiply;
    [SerializeField] private Rigidbody rb;
    private IEmployee _employee;
    private Vector3 randomCircle;

    public void Configure(IEmployee employee)
    {
        _employee = employee;
        randomCircle = Random.insideUnitSphere * multiply;
        randomCircle.y = _employee.GetPosition().y;
    }

    public Vector3 GetPointToOpponents()
    {
        return targetToOpponents.transform.position + randomCircle;
    }
    private void Rotating (float horizontal, float vertical)
    {
        Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        Quaternion newRotation = Quaternion.Lerp(rb.rotation, targetRotation, 100 * Time.deltaTime);
        rb.MoveRotation(newRotation);
    }
    public void Rotate()
    {
        var targetDir = _employee.GetObjective() - _employee.GetPosition();
        /*var angle = Vector3.Angle(targetDir, -transform.forward);
        pointToObject.transform.eulerAngles = new Vector3(0, angle, 0);*/
        Rotating(targetDir.x, targetDir.z);
    }
}