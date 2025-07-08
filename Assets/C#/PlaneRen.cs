using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRen : MonoBehaviour
{
    Vector3 diff;
    Vector3 lastVec;

    void Start()
    {
        lastVec = transform.position;
    }

    void Update()
    {
        diff = transform.position - lastVec;
        lastVec = transform.position;
        if (diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(diff);
        }
    }
}
