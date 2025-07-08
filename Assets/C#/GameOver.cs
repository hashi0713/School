using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameOver : MonoBehaviour
{
    public GameObject stick;
    public GameObject button;
    public GameObject MenuBG;
    public GameObject text;
    public GameObject text2;
    public GameObject life;
    public GameObject dash;
    public GameObject restart;
    public GameObject home;
    public GameObject stop;
    public Plane plane;
    public Interstitial_AdMob adMob;
    void Start()
    {
        
    }

    void Update()
    {
        //if (plane.isTouch || plane.lifePoint <= 0) {SceneManager.LoadScene("Game"); }
            var current = Keyboard.current;
        //if (current.rKey.wasReleasedThisFrame) { if (Random.Range(1, 3) == 1) { adMob.start = true; adMob.select = 1; } else { SceneManager.LoadScene("Game"); } }
        //if (current.hKey.wasReleasedThisFrame) { if (Random.Range(1, 3) == 1) { adMob.start = true; adMob.select = 2; } else { SceneManager.LoadScene("Start"); } }
        if (current.rKey.wasReleasedThisFrame)SceneManager.LoadScene("Game");
        //if (current.hKey.wasReleasedThisFrame)SceneManager.LoadScene("Start");
    }
    private void Game_Over()
    {
        life.SetActive(false);
        dash.SetActive(false);
        button.SetActive(false);
        stick.SetActive(false);
        stop.SetActive(false);
        restart.SetActive(true);
        home.SetActive(true);
        MenuBG.SetActive(true);
        text.SetActive(true);
        text2.SetActive(true);
        Time.timeScale = 0;
    }
}
