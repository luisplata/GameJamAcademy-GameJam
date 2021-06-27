using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionToDestroidOtherElements : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<InteractiveToDestroyed>(out var output))
        {
            output.StartToDestroyed();
        }
    }
}