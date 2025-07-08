using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartCamera : MonoBehaviour
{
    public GameObject plane;
    public GameObject StartButton;
    public GameObject SelectButton;
    public GameObject SelectSec;
    public GameObject nameText;
    public GameObject helpButton;
    [SerializeField] private float x = 0;
    [SerializeField] private float y = 0;
    [SerializeField] private float z = 0;
    private bool stop;
    public bool off;
    [SerializeField]private bool select;
    private void Start()
    {
        stop = false;
        select = false;
        off = false;
        transform.position = new Vector3(plane.transform.position.x + x, plane.transform.position.y + y, plane.transform.position.z - z);
        transform.rotation = Quaternion.Euler(40,0,0);
    }
    void Update()
    {
        var current = Keyboard.current;
        if (current == null) return;
        if (current.gKey.wasPressedThisFrame) stop = true;
        if (current.sKey.wasPressedThisFrame&&!stop) select = true;
        if (current.bKey.wasPressedThisFrame) select = false;
        if (!stop)
        {
            transform.position = new Vector3(plane.transform.position.x + x, plane.transform.position.y + y, plane.transform.position.z - z);
        }
        
        
    }
    private void FixedUpdate()
    {
        if (stop && transform.rotation.eulerAngles.x < 180)
        {
            transform.Translate(0, -0.1f, 0);
            transform.Rotate(-0.5f, 0, 0);
        }
        if (select)
        {
            Invoke("Select1", 0.1f);
            x = 1;y = 1.75f;z = -6;
            if (transform.rotation.eulerAngles.x >= 20) transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x - 2, transform.rotation.eulerAngles.y - 17, 0);
            if(transform.rotation.eulerAngles.x<20) transform.rotation = Quaternion.Euler(20, -170, 0);
            off = true;
        }
        if (!select && off)
        {
            Invoke("Select2", 0.1f);
            x = 2; y = 5; z = 5;
            if (transform.rotation.eulerAngles.x <= 40) transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x + 2, transform.rotation.eulerAngles.y + 17, 0);
            if (transform.rotation.eulerAngles.x > 40) { transform.rotation = Quaternion.Euler(40, 0, 0); off = false; }
        }
    }

    void Select1()
    {
        StartButton.SetActive(false);
        SelectButton.SetActive(false);
        helpButton.SetActive(false);
        SelectSec.SetActive(true);

        nameText.SetActive(true);
    }
    void Select2()
    {
        StartButton.SetActive(true);
        SelectButton.SetActive(true);
        helpButton.SetActive(true);
        SelectSec.SetActive(false);

        nameText.SetActive(false);
    }
}
