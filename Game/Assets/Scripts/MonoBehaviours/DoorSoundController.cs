using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DoorSoundController : MonoBehaviour
{

    public AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = sound;
    }

    void OnTriggerEnter2D ()
    {
        GetComponent<AudioSource>().Play();
    }
}
