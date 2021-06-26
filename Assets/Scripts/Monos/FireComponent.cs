using System;
using UnityEngine;

public class FireComponent : MonoBehaviour
{
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }
}