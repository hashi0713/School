using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMapGenerator : MonoBehaviour
{
    public GameObject ground1;
    public GameObject player;

    private const float start = 300;
    private const float distance = 700;
    private float count = 0;
    void Start()
    {
        count += start;
    }

    void Update()
    {
        if (player.transform.position.z + 1000 >= count)
        {
            count += distance;
            Instantiate(ground1, new Vector3(0, -0.6f, count), Quaternion.identity);
            Instantiate(ground1, new Vector3(300, -0.6f, count), Quaternion.identity);
            Instantiate(ground1, new Vector3(-300, -0.6f, count), Quaternion.identity);
            Instantiate(ground1, new Vector3(600, -0.6f, count), Quaternion.identity);
            Instantiate(ground1, new Vector3(-600, -0.6f, count), Quaternion.identity);
        }
    }
}
