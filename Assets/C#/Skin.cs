using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour
{
    public GameObject plane1;
    public GameObject plane2;
    public GameObject plane3;
    public GameObject plane4;
    public GameObject plane5;
    public int skin;
    void Start()
    {
        skin = PlayerPrefs.GetInt("Skin", 1);
        switch (skin)
        {
            case 1: Plane1(); break;
            case 2: Plane2(); break;
            case 3: Plane3(); break;
            case 4: Plane4(); break;
            case 5: Plane5(); break;
        }
    }
    void Plane1()
    {
        plane1.SetActive(true);
        plane2.SetActive(false);
        plane3.SetActive(false);
        plane4.SetActive(false);
        plane5.SetActive(false);
    }
    void Plane2()
    {
        plane1.SetActive(false);
        plane2.SetActive(true);
        plane3.SetActive(false);
        plane4.SetActive(false);
        plane5.SetActive(false);
    }
    void Plane3()
    {
        plane1.SetActive(false);
        plane2.SetActive(false);
        plane3.SetActive(true);
        plane4.SetActive(false);
        plane5.SetActive(false);
    }
    void Plane4()
    {
        plane1.SetActive(false);
        plane2.SetActive(false);
        plane3.SetActive(false);
        plane4.SetActive(true);
        plane5.SetActive(false);
    }
    void Plane5()
    {
        plane1.SetActive(false);
        plane2.SetActive(false);
        plane3.SetActive(false);
        plane4.SetActive(false);
        plane5.SetActive(true);
    }
}
