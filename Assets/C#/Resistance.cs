using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resistance : MonoBehaviour
{
    Rigidbody rd;
    [SerializeField] private float coe;
    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rd.AddForce(Vector3.back * rd.velocity.z * coe);
    }
}
