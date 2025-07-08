using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyScore : MonoBehaviour
{
    Text text;
    public StartCamera select;
    private int score;
    void Start()
    {
        text = GetComponent<Text>();
        score = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        if(!select.off)text.text = "HIGH SCORE:" + score + "P";
        if (select.off) text.text = null;
    }
}
