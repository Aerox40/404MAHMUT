using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Test : MonoBehaviour
{
    public AudioSource audioSource;
    public static bool lever1;

    CinemachineImpulseSource impulse;
    void Start()
    {
        impulse = transform.GetComponent<CinemachineImpulseSource>();
    }

    void Update()
    {      
    }

    void shake()
    {
        impulse.GenerateImpulse(2f);
        if (!lever1)
        {
            Invoke("shake", 5f);
        }
        else 
        {
          Invoke("stopAudio",5f);
        }
    }

    public void invokedShake()
    {
        Invoke("shake", 5f);
        Invoke("playAudio", 5f);
    }

    public void StopEarthquake()
    {
        lever1 = true;
    }

    void playAudio()
    {
        audioSource.Play();
    }

    void stopAudio()
    {
        audioSource.Stop();
    }
}
