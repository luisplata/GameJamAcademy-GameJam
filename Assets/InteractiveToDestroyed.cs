using UnityEngine;

public class InteractiveToDestroyed : MonoBehaviour
{
    public void StartToDestroyed()
    {
        Debug.Log("Start destroyed");
        Destroy(gameObject);
    }
}