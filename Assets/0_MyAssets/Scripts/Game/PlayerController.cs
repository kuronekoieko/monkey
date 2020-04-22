using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Release();
        }
        CheckFall();
    }

    void OnCollisionEnter(Collision col)
    {
        CheckGoal(col);
    }

    void Release()
    {
        rb.isKinematic = false;
        transform.parent = null;
        rb.velocity = transform.forward * 70;
        animator.SetTrigger("Jump");
    }

    public void Grab(Transform target)
    {
        rb.isKinematic = true;
        transform.parent = target;
        transform.rotation = target.rotation;
        Vector3 pos = transform.localPosition;
        pos.z = -1.33f;
        transform.localPosition = pos;
        CameraController.i.Move(60);
        animator.SetTrigger("Idle");
    }

    void CheckGoal(Collision col)
    {
        if (!col.transform.CompareTag("Goal")) { return; }

        transform.eulerAngles = Vector3.zero;
        rb.velocity = Vector3.zero;
        CameraController.i.Move(50);
        Variables.screenState = ScreenState.Clear;
    }

    void CheckFall()
    {
        if (transform.position.y > -40) { return; }

        Variables.screenState = ScreenState.Failed;

    }

}
