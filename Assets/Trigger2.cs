using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2 : MonoBehaviour
{
    public GameObject canvas;

    void Start()
    {  
    }

    void Update()
    { 
    }

    private void OnTriggerStay(Collider finishTri)
    {
        if (finishTri.name == "PlayerCapsule")
        {
            print("hello");
            canvas.GetComponent<PauseMenu>().panel6Open();
        }
    }
}
