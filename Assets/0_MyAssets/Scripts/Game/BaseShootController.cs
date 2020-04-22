using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShootController : MonoBehaviour
{
    bool isGrabbed;

    void Start()
    {
        isGrabbed = false;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player == null) { return; }
        Debug.Log("b");
        if (isGrabbed) { return; }
        isGrabbed = true;
        player.Grab(target: transform);
        Debug.Log("aaaaaaaaaaaaaaaaaaaa");
    }


}
