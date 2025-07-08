using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limit : MonoBehaviour
{
    Rigidbody rd;
    [SerializeField] private float downSpeed = 0;
    private const float limit_x = 50;
    private const float limit_y = 200;
    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.x >= 50) rd.AddForce(Mathf.Abs(rd.velocity.x) * -1.5f * downSpeed, 0, 0, ForceMode.VelocityChange);
        if (transform.position.x <= -50) rd.AddForce(Mathf.Abs(rd.velocity.x) * 1.5f * downSpeed, 0, 0, ForceMode.VelocityChange);
    }
}
