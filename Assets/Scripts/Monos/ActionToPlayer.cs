using UnityEngine;

public class ActionToPlayer : IActionToPlayer
{
    private readonly IEmployee _employee;

    private bool _canInteractive;
    private GameObject _gameObject;

    public ActionToPlayer(IEmployee employee)
    {
        _employee = employee;
    }

    public bool CanInteractive()
    {
        return _canInteractive;
    }

    public void CantInteractive()
    {
        _canInteractive = false;
        _gameObject = null;
    }

    public void CanInteractive(GameObject otherGameObject)
    {
        _canInteractive = true;
        _gameObject = otherGameObject;
    }

    public void InteractiveToTheObject()
    {
        if (_gameObject.CompareTag("Goal"))
        {
            _employee.DeliveryToBook();
        }

        if (_gameObject.CompareTag("Interac") || _gameObject.CompareTag("Ali"))
        {
            _employee.ConvertAli(_gameObject);
        }
    }
}