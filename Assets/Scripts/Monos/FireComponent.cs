using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Game Over
            ServiceLocator.Instance.GetService<IStatusGame>().GameOver();
        }
        if (other.gameObject.CompareTag("Interac") || other.gameObject.CompareTag("Opponent"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Untagged"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 200);
        }
    }
}