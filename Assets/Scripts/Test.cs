using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Test : MonoBehaviour
{
    CinemachineImpulseSource impulse;
    // Start is called before the first frame update
    void Start()
    {
        impulse = transform.GetComponent<CinemachineImpulseSource>();

        Invoke("shake", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void shake()
    {
        print("heyy");
        impulse.GenerateImpulse(10f);
    }
}
