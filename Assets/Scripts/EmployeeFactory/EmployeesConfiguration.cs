using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bellseboss/EmployeeConfiguration")]
public class EmployeesConfiguration : ScriptableObject
{
    [SerializeField] private Employee[] employees;
    private Dictionary<string, Employee> idToEmployee;

    private void Awake()
    {
        idToEmployee = new Dictionary<string, Employee>(employees.Length);
        foreach (var employee in employees)
        {
            idToEmployee.Add(employee.Id, employee);
        }
    }

    public EmployeeBuilder GetEmployeePrefabById(string id)
    {
        return new EmployeeBuilder(idToEmployee[id]);
    }
}