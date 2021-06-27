using UnityEngine;

public class EmployeesFactory
{
    private readonly EmployeesConfiguration employeesConfiguration;

    public EmployeesFactory(EmployeesConfiguration employeesConfiguration)
    {
        this.employeesConfiguration = employeesConfiguration;
    }
        
    public EmployeeBuilder Create(EmployeeScriptable id)
    {
        var prefab = employeesConfiguration.GetEmployeePrefabById(id);
        return prefab;
    }
}