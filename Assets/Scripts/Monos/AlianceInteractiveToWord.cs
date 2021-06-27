using System;
using UnityEngine;

public class AlianceInteractiveToWord : MonoBehaviour
{
    private IEmployee _employee;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Opponent"))
        {
            _employee.GetSkill().ActionSkill();
        }
    }

    public void Configure(IEmployee employee)
    {
        _employee = employee;
    }
}