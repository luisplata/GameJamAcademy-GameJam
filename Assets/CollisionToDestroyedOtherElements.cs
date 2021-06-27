using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionToDestroyedOtherElements : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<InteractiveToDestroyed>(out var output))
        {
            output.StartToDestroyed();
        }
    }

    private void OnCollisionEnter(Collision other)
    {

    }
}