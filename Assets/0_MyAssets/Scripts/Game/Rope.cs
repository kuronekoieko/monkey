using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{

    /*
    【Unity】なわとびの縄のシミュレーション
    http://nn-hokuson.hatenablog.com/entry/2018/01/30/200050
    */

    LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Unlit/Color"));
        line.positionCount = transform.childCount;

        foreach (Transform v in transform)
        {
            v.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void Update()
    {
        int idx = 0;
        foreach (Transform v in transform)
        {
            line.SetPosition(idx, v.position);
            idx++;
        }
    }
}