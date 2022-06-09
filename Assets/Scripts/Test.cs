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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void shake()
    {
        impulse.GenerateImpulse(5f);
    }

    public void invokedShake()
    {
        Invoke("shake", 5f);     
    }
}
