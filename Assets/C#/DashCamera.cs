using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCamera : MonoBehaviour
{
    public Camera cam;

    private static float min = 60;
    private static float max = 90;
    private static float space = 30;

    [System.NonSerialized] public bool isDash = false;
    [System.NonSerialized] public bool isDash2 = false;
    [SerializeField] private float dashTime = 0;

    private float dashTimer = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (isDash)
        {
            if (cam.fieldOfView <= max) cam.fieldOfView += space / 10;
            if (cam.fieldOfView >= max) cam.fieldOfView = max;
            dashTimer += Time.deltaTime;
            if (isDash2) { dashTimer = 0; isDash2 = false; }
        }
        if (dashTimer >= dashTime)
        {
            isDash = false;
            dashTimer = 0;
        }
        if (!isDash)
        {
            if (cam.fieldOfView >= min) cam.fieldOfView -= space / 100;
            if (cam.fieldOfView <= min) cam.fieldOfView = min;
        }
    }
}
