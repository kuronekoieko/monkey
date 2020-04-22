using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        //rb.velocity = Vector3.forward * speed;
        if (Input.GetMouseButtonDown(0))
        {
            rb.isKinematic = false;
            //rb.useGravity = true;
            transform.parent = null;
            rb.velocity = transform.forward * 50;
        }

    }

    void OnCollisionEnter(Collision col)
    {

    }

    void OnTriggerEnter(Collider other)
    {

    }

    public void Grab(Transform target)
    {
        rb.isKinematic = true;
        transform.parent = target;
        transform.rotation = target.rotation;
    }

}
