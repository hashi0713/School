using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlane : MonoBehaviour
{
    private Rigidbody rd;

    private void Start()
    {
        rd = GetComponent<Rigidbody>();
        rd.AddForce(0, 0, 50, ForceMode.VelocityChange);
    }
}
