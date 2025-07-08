using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlane : MonoBehaviour
{
    private float i = 0;
    private float rot = 0;
    [SerializeField] private float move_y = 0;
    [SerializeField] private float default_y = 0;
    void FixedUpdate()
    {
        rot += 3;
        i = rot * Mathf.Deg2Rad;
        transform.localPosition = new Vector3(transform.localPosition.x, default_y-0.01f + Mathf.Sin(i) / move_y, transform.localPosition.z);
    }
}
