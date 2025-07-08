using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointRot : MonoBehaviour
{
    [SerializeField] private float rotSpeed = 0;
    void FixedUpdate()
    {
        transform.Rotate(0, rotSpeed, 0, Space.World);
    }
}
