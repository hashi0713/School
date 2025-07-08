using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalGravity : MonoBehaviour
{
    Rigidbody rd;

    [SerializeField] private float GravityScale = 0;

    Vector3 localGravity = Vector3.down;

    void Start()
    {
        rd = GetComponent<Rigidbody>();
        rd.useGravity = false;
        localGravity *= GravityScale;
    }

    void FixedUpdate()
    {
        Gravity();    
    }

    private void Gravity()
    {
        rd.AddForce(localGravity, ForceMode.Acceleration);
    }
}
