using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameStart : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        var current = Keyboard.current;
        if (current == null) return;
        if (current.gKey.wasPressedThisFrame) Invoke("Load", 1.5f);
    }
    private void Load()
    {
        SceneManager.LoadScene("Game");
    }
}
