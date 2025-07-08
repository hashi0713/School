using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private float time = 0;
    public GameObject plane;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        if (time >= 10)
        {
            GameObject[] buildings;
            buildings = GameObject.FindGameObjectsWithTag("Building");
            foreach(GameObject buck in buildings)
            {
                if (plane.transform.position.z >= buck.transform.position.z + 1500) Destroy(buck);
            }
        }
    }
}
