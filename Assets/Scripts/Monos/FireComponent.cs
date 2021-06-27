using System;
using UnityEngine;

public class FireComponent : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 _target;
    [SerializeField] private Vector3 normalized;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    public void Configure(Vector3 target)
    {
        _target = target;
        normalized = (_target - transform.position).normalized;
    }

    private void Update()
    {
        rb.velocity = normalized * (300 * Time.deltaTime);
    }
}