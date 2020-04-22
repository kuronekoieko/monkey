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
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player == null) { return; }
        if (isGrabbed) { return; }
        isGrabbed = true;
        player.Grab(target: transform);
    }


}
