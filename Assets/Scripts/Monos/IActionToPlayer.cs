using UnityEngine;

public interface IActionToPlayer
{
    bool CanInteractive();
    void CantInteractive();
    void CanInteractive(GameObject otherGameObject);
    void InteractiveToTheObject();
}