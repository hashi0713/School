using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class StartBGM : MonoBehaviour
{
    public AudioClip sound1;
    public AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound1);
    }
}
