using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
   
    public Animator animator;
    private Vector3 input;

    private void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if (input != Vector3.zero)
            Move();

        if (Input.GetKeyDown(KeyCode.Space))
            Power();

        if (Input.GetKeyDown(KeyCode.F))
            Give();

    }

    private void Move()
    {
            animator.SetFloat("speed",input.magnitude);      
    }
    private void Power()
    {
        animator.SetTrigger("power");
    }
    private void Give()
    {
        animator.SetTrigger("give");
    }
}
