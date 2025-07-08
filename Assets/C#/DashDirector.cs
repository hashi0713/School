using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashDirector : MonoBehaviour
{
    public Plane plane;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;

    void Start()
    {
        
    }

    void Update()
    {
        switch (plane.dashPoint)
        {
            case 0:
                cube1.SetActive(false);
                cube2.SetActive(false);
                cube3.SetActive(false);
                break;
            case 1:
                cube1.SetActive(true);
                cube2.SetActive(false);
                cube3.SetActive(false);
                break;
            case 2:
                cube1.SetActive(true);
                cube2.SetActive(true);
                cube3.SetActive(false);
                break;
            case 3:
                cube1.SetActive(true);
                cube2.SetActive(true);
                cube3.SetActive(true);
                break;

        }
    }
}
