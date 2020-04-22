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
            rb.velocity = transform.forward * 70;
        }

    }

    void OnCollisionEnter(Collision col)
    {
        CheckGoal(col);
    }

    public void Grab(Transform target)
    {
        rb.isKinematic = true;
        transform.parent = target;
        transform.rotation = target.rotation;
        CameraController.i.Move(40);
    }

    void CheckGoal(Collision col)
    {
        if (!col.transform.CompareTag("Goal")) { return; }

        transform.eulerAngles = Vector3.zero;
        rb.velocity = Vector3.zero;
        CameraController.i.Move(50);

    }

}
