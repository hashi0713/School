using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Stop : MonoBehaviour
{
    private bool isStop = false;
    private float time = 0;
    [SerializeField]private GameObject[] uI;
    [SerializeField] private GameObject[] button;
    void Start()
    {
        isStop = false;
    }

    void Update()
    {
        var current = Keyboard.current;
        if (current.sKey.wasPressedThisFrame&&!isStop) isStop = true;
        if (isStop) IsStop();
        
    }
    void IsStop()
    {
        Time.timeScale = 0;
        foreach(GameObject ui in uI) ui.SetActive(false);
        foreach (GameObject button_GO in button) button_GO.SetActive(true);
        var current = Keyboard.current;
        if (current.tKey.wasPressedThisFrame) CancelStop();
    }
    void CancelStop()
    {
        Time.timeScale = 1;
        foreach (GameObject ui in uI) ui.SetActive(true);
        foreach (GameObject button_GO in button) button_GO.SetActive(false);
        isStop = false;
    }
}
