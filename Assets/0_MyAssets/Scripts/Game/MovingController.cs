using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingController : MonoBehaviour
{

    [SerializeField] Vector3 direction = new Vector3(30, 0, 0);
    Sequence sequence;
    void Start()
    {
        sequence = DOTween.Sequence()
        .Append(transform.DOMove(direction, 1).SetRelative())
        .Append(transform.DOMove(-direction, 1).SetRelative());
        sequence.SetLoops(-1);
    }


}
