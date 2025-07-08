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
        transform.rotation = Quaternion.Euler(15, 0, 0);   
    }

    void LateUpdate()
    {
        transform.position = new Vector3(plane.transform.position.x + x, plane.transform.position.y + y, plane.transform.position.z - z);
    }
}
