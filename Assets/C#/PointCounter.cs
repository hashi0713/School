using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    public int point;

    public GameObject counter;
    private Text text;
    void Start()
    {
        text = counter.GetComponent<Text>();
    }

    void Update()
    {
        text.text = point.ToString() + "P";
    }
}
