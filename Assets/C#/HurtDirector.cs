using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtDirector : MonoBehaviour
{
    public Plane plane;
    public GameObject hurt1;
    public GameObject hurt2;
    public GameObject hurt3;
    void Start()
    {
        
    }

    void Update()
    {
        switch (plane.lifePoint)
        {
            case 0:
                hurt1.SetActive(false);
                hurt2.SetActive(false);
                hurt3.SetActive(false);
                
                break;
            case 1:
                hurt1.SetActive(true);
                hurt2.SetActive(false);
                hurt3.SetActive(false);
                break;
            case 2:
                hurt1.SetActive(true);
                hurt2.SetActive(true);
                hurt3.SetActive(false);
                break;
            case 3:
                hurt1.SetActive(true);
                hurt2.SetActive(true);
                hurt3.SetActive(true);
                break;
        }
    }
}
