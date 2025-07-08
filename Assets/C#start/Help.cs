using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Help : MonoBehaviour
{
    private bool isHelp = false;
    public GameObject help;
    public GameObject help_BG;
    public GameObject[] startUI;
    void Start()
    {
        
    }
    void Update()
    {
        var current = Keyboard.current;
        if (current.hKey.wasPressedThisFrame) isHelp = true;
        if (isHelp) IsHelp();
    }
    void IsHelp()
    {
        help.SetActive(true);
        help_BG.SetActive(true);
        foreach(GameObject ui in startUI) ui.SetActive(false);
        if (Input.GetMouseButtonDown(0))
        {
            help.SetActive(false);
            help_BG.SetActive(false);
            foreach(GameObject ui in startUI) ui.SetActive(true);
            isHelp = false;
            
        }
    }
}
