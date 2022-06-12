using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject canvas;

    void Start()
    {   
    }

    void Update()
    {
    }
    private void OnTriggerStay(Collider lifeTri)
    {
        if (lifeTri.name == "PlayerCapsule" && Input.GetKey(KeyCode.LeftControl) && !Test.lever1)
        {
            print("hello");
            canvas.GetComponent<PauseMenu>().invokedPanel3Open();
        }
    }
}
