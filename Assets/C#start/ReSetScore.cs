using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSetScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }
}
