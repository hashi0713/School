using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public PointCounter point;

    public GameObject counter;
    private  Text text;
    private bool stop;


    private int i = 0;
    void Start()
    {
        text = counter.GetComponent<Text>();
        point = GameObject.Find("Point").GetComponent<PointCounter>();
        stop = false;
    }

    void Update()
    {
                text.text = i.ToString() + "P";
        if (i < point.point) i++;
        if (Input.GetMouseButton(0) && !stop) { i = point.point; stop = true; }
    }
}
