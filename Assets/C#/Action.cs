using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Action : MonoBehaviour
{
    //Tern
    [SerializeField] private float tern_Rot = 0;
    private float count = 0;

    public Plane plane;
    void Start()
    {
        
    }

    void Update()
    {
        var current = Keyboard.current;
        if (current == null)
            return;
        if (current.spaceKey.wasPressedThisFrame && count == 0) InvokeRepeating("Tern", 0, 0.01f);
        if (plane.tern && count == 0) { InvokeRepeating("Tern", 0, 0.01f); plane.tern = false; }
        if (count >= 360) { CancelInvoke("Tern"); transform.rotation = new Quaternion(0,0,0,0); count = 0;}
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ring")
        {
            InvokeRepeating("Tern", 0, 0.01f);
        }
    }

    private void Tern()
    {
        transform.Rotate(0, 0, tern_Rot);
        count += tern_Rot;
    }
}
