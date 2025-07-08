using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SkinSelect : MonoBehaviour
{
    public int skin = 0;
    public int desSkin = 0;
    private int highScore = 0;
    private bool up = false;
    public GameObject plane1;
    public GameObject plane2;
    public GameObject plane3;
    public GameObject plane4;
    public GameObject plane5;
    public Text text;
    public Text nameText;
    private string[] name = {"NOMAL","ACROBAT","AIR PLANE","DUCK","TREE" };
    public GameObject textup;
    public GameObject question;
    [SerializeField] private int lock2;
    [SerializeField] private int lock3;
    [SerializeField] private int lock4;
    [SerializeField] private int lock5;
    [SerializeField] private float upTime = 0;

    private float timer = 0;


    void Start()
    {
        desSkin = skin = PlayerPrefs.GetInt("Skin", 1);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        switch (skin)
        {
            case 1:Plane1();break;
            case 2:Plane2();break;
            case 3:Plane3();break;
            case 4:Plane4();break;
            case 5:Plane5();break;
        }
    }

    void Update()
    {
        var current = Keyboard.current;
        if (current.digit1Key.wasPressedThisFrame) { skin = skin != 1 ? skin - 1 : 5; }
        if (current.digit2Key.wasPressedThisFrame) { skin = skin != 5 ? skin + 1 : 1; }
        switch (skin)
        {
            case 1: Plane1(); break;
            case 2: Plane2(); break;
            case 3: Plane3(); break;
            case 4: Plane4(); break;
            case 5: Plane5(); break;
        }

        nameText.text = name[skin-1];

        if (current.digit3Key.wasPressedThisFrame)
        {
            if (skin == 2 && highScore <= lock2) { up = true; text.text = "UNLOCK:" + lock2.ToString() + "~"; }
            else if (skin == 3 && highScore <= lock3) { up = true; text.text = "UNLOCK:" + lock3.ToString() + "~"; }
            else if (skin == 4 && highScore <= lock4) { up = true; text.text = "UNLOCK:" + lock4.ToString() + "~"; }
            else if (skin == 5 && highScore <= lock5) { up = true; text.text = "UNLOCK:" + lock5.ToString() + "~"; }
            else { desSkin = skin; }
        }




        if (up)
        {
            timer += Time.deltaTime;
            textup.SetActive(true);
        }
        if (up && upTime <= timer)
        {
            textup.SetActive(false);
            up = false;
            timer = 0;
        }
        if (current.bKey.wasPressedThisFrame)
        {
            skin = desSkin;
            switch (desSkin)
            {
                case 1: Plane1(); break;
                case 2: Plane2(); break;
                case 3: Plane3(); break;
                case 4: Plane4(); break;
                case 5: Plane5(); break;
            }
            PlayerPrefs.SetInt("Skin", desSkin);
            PlayerPrefs.Save();
        }
    }
    void Rot()
    {
    }
    void Plane1()
    {
        question.SetActive(false);
        plane1.SetActive(true);
        plane2.SetActive(false);
        plane3.SetActive(false);
        plane4.SetActive(false);
        plane5.SetActive(false);
    }
    void Plane2()
    {
        if (highScore <= lock2)
        {
            question.SetActive(true);
            plane1.SetActive(false);
            plane2.SetActive(false);
            plane3.SetActive(false);
            plane4.SetActive(false);
            plane5.SetActive(false);
        }
        else
        {
            question.SetActive(false);
            plane1.SetActive(false);
            plane2.SetActive(true);
            plane3.SetActive(false);
            plane4.SetActive(false);
            plane5.SetActive(false);
        }
    }
    void Plane3()
    {
        if (highScore <= lock3)
        {
            question.SetActive(true);
            plane1.SetActive(false);
            plane2.SetActive(false);
            plane3.SetActive(false);
            plane4.SetActive(false);
            plane5.SetActive(false);
        }
        else
        {
            question.SetActive(false);
            plane1.SetActive(false);
            plane2.SetActive(false);
            plane3.SetActive(true);
            plane4.SetActive(false);
            plane5.SetActive(false);
        }
    }
    void Plane4()
    {
        if (highScore <= lock4)
        {
            question.SetActive(true);
            plane1.SetActive(false);
            plane2.SetActive(false);
            plane3.SetActive(false);
            plane4.SetActive(false);
            plane5.SetActive(false);
        }
        else
        {
            question.SetActive(false);
            plane1.SetActive(false);
            plane2.SetActive(false);
            plane3.SetActive(false);
            plane4.SetActive(true);
            plane5.SetActive(false);
        }
    }
    void Plane5()
    {
        if (highScore <= lock5)
        {
            question.SetActive(true);
            plane1.SetActive(false);
            plane2.SetActive(false);
            plane3.SetActive(false);
            plane4.SetActive(false);
            plane5.SetActive(false);
        }
        else
        {
            question.SetActive(false);
            plane1.SetActive(false);
            plane2.SetActive(false);
            plane3.SetActive(false);
            plane4.SetActive(false);
            plane5.SetActive(true);
        }
    }
}
