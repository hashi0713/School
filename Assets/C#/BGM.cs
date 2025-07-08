using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{


    public AudioClip sound1;
    public AudioSource audioSource;
    public Plane plane;
    private bool one = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!one)
        {
            audioSource.PlayOneShot(sound1);
            one = true;
        }
        var volume = plane.rd.velocity.magnitude / 500;
        if (volume >= 1) volume = 1;
        audioSource.volume = volume;
        //if (plane.isTouch || plane.lifePoint <= 0) gameObject.SetActive(false);
    }
}
