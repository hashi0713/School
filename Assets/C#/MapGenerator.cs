using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject ground1;
    public GameObject ground1_R;
    public GameObject ground1_L;
    public GameObject ground2_R;
    public GameObject ground2_L;
    public Plane player;

    private const float start = 300;
    private const float distance = 700;
    private float count = 0;

    private float i = 0;
    void Start()
    {
        count += start;
    }

    void Update()
    {
        if (player.transform.position.z + 1000 >= count)
        {
            count += distance;
            i++;
            Instantiate(ground1, new Vector3(0, -0.6f, count), Quaternion.identity);
            Instantiate(ground1_R, new Vector3(300, -0.6f, count), Quaternion.identity);
            Instantiate(ground1_L, new Vector3(-300, -0.6f, count), Quaternion.identity);
            Instantiate(ground2_R, new Vector3(600, -0.6f, count), Quaternion.identity);
            Instantiate(ground2_L, new Vector3(-600, -0.6f, count), Quaternion.identity);

        }
    }
}
