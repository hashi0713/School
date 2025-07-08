using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotPlane : MonoBehaviour
{
    [SerializeField]private bool isRot = false;
    [SerializeField]private float rotSpeed = 0;
    private float rotCount = 0;
    void Start()
    {
        
    }

    private void Update()
    {
        var current = Keyboard.current;
        if (current.digit1Key.wasPressedThisFrame||current.digit2Key.wasPressedThisFrame)isRot = true;
    }
    void FixedUpdate()
    {
        
        if (isRot && rotCount <= 360)
        {
            transform.Rotate(0, 0, rotSpeed);
            rotCount += rotSpeed;
        }
        if (rotCount >= 360&&isRot)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isRot = false;
            rotCount = 0;
        }
    }
}
