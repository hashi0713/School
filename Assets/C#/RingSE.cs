using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSE : MonoBehaviour
{
    public AudioClip sound1;
    public AudioSource audioSource;
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
    }
}
