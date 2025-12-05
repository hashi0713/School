using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingGenerator : MonoBehaviour
{
    public Plane player;
    public GameObject ring;
    private const float minx = -30;
    private const float miny = 30;
    private const float maxy = 180;
    private const float start = 100;
    private float dis = 0;
    private float count = 0;
    void Start()
    {
        count += start;
        dis = Random.Range(650,700);

    }
    void Update()
    {
        if (player.transform.position.z + 1000 >= count)
        {
            count += dis;
            Instantiate(ring, new Vector3(Random.Range(minx, -minx), Random.Range(miny, maxy), count), Quaternion.identity);
            dis = Random.Range(750, 1000);

            GameObject[] terget;
            terget = GameObject.FindGameObjectsWithTag("Building");
            foreach (GameObject back in terget)
            {
                if (back.transform.position.z <= transform.position.z - 300)
                {
                    Destroy(back);
                }
            }
        }

        if (player.ringReset)
        {
            GameObject[] rings;
            rings = GameObject.FindGameObjectsWithTag("Ring");
            foreach(GameObject ring in rings)
            {
                Destroy(ring);
            }
            Instantiate(ring, new Vector3(0,75,100), Quaternion.identity);
            count = start;
            dis = Random.Range(650, 700);
            player.ringReset = false;
        }

    }
}
