using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    private PointCounter point;
    public GameObject counter;
    private Text text;
    private float highScore;
    void Start()
    {
        point = GameObject.Find("Point").GetComponent<PointCounter>();
        if (point.point >= PlayerPrefs.GetInt("HighScore", 0)) { PlayerPrefs.SetInt("HighScore", point.point); PlayerPrefs.Save(); }
        text = counter.GetComponent<Text>();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        text.text = "HIGHSCORE:" + highScore.ToString() + "P";
    }
}
