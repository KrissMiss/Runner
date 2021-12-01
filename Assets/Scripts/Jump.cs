using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jump"))
        {
            rb.AddForce(0, transform.position.y + 30, 0, ForceMode.Impulse);
            anim.SetTrigger("Jump");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Jump"))
        {
            anim.SetBool("Run", true);
        }
       
    }
}
