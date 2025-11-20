using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRen : MonoBehaviour
{
    private Vector3 lastVec;

    public void ResetLastVec(Vector3 pos)
    {
        lastVec = pos;
    }

    void Update()
    {
        Vector3 p = transform.rotation.eulerAngles;
        Vector3 diff = transform.position - lastVec;
        lastVec = transform.position;
        if (diff.sqrMagnitude > 0.0001f) transform.rotation = Quaternion.LookRotation(diff);
        //if (transform.eulerAngles.x > 85 && transform.eulerAngles.x <= 180) transform.rotation = Quaternion.Euler(85, p.y, p.z);
        //if (transform.eulerAngles.x < 305 && transform.eulerAngles.x >= 180) transform.rotation = Quaternion.Euler(305, p.y, p.z);
        //if (transform.eulerAngles.y > 85 && transform.eulerAngles.y <= 180) transform.rotation = Quaternion.Euler(p.x, 85, p.z);
        //if (transform.eulerAngles.y < 305 && transform.eulerAngles.y >= 180) transform.rotation = Quaternion.Euler(p.x, 305, p.z);

    }
}
