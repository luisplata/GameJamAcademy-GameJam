using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractToTheAmbient : MonoBehaviour
{
    private IEmployee _employee;

    public void Configure(IEmployee employee)
    {
        _employee = employee;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interac") || other.gameObject.CompareTag("Goal"))
        {
            _employee.CanInteractive(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interac") || other.gameObject.CompareTag("Goal"))
        {
            _employee.CantInteractive();
        }
    }
}
