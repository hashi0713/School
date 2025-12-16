using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public GameObject counter;
    private Text text;
    private float highScore;
    void Start()
    {
        if (PointManeger.Instance.Score >= PlayerPrefs.GetInt("HighScore", 0)) { PlayerPrefs.SetInt("HighScore", PointManeger.Instance.Score); PlayerPrefs.Save(); }
        text = counter.GetComponent<Text>();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        text.text = "HIGHSCORE:" + highScore.ToString() + "P";
    }
}
