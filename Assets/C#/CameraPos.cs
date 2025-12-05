using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    [SerializeField] private Vector3 t;
    [SerializeField] private Vector3 q;
    public Plane plane;
    void Start()
    {
           
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(q);

        transform.position = plane.transform.position + t;
    }
}
