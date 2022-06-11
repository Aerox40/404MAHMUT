using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2 : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider finishTri)
    {
        //print(lifeTri.name);
        if (finishTri.name == "PlayerCapsule")
        {
            print("hello");
            canvas.GetComponent<PauseMenu>().panel6Open();
        }
    }
}
