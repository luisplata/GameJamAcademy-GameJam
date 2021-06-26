using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeMono : MonoBehaviour
{
    private IEmployee _employee;

    public void Config(IEmployee employee)
    {
        _employee = employee;
    }
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            _employee.LaunchTheBook();
        }

        if (other.gameObject.CompareTag("Book"))
        {
            Destroy(other.gameObject);
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Opponent"))
        {
            _employee.ListOfOpponents.Add(other.gameObject.GetComponent<Employee>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Opponent"))
        {
            _employee.ListOfOpponents.Remove(other.gameObject.GetComponent<Employee>());
        }
    }
}
