using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveTest : MonoBehaviour
{
    [SerializeField]private Vector3 input;
    [SerializeField] private Rigidbody rg;
    [SerializeField] private float speed=10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        rg.MovePosition(transform.position +input *Time.deltaTime* speed);
    }
}
