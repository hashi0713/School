using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;
    public Plane plane;
    void Start()
    {
           
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(15, 0, 0);

        transform.position = plane.transform.position + new Vector3(x, y, z);
    }
}
