using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
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
    private void OnTriggerStay(Collider lifeTri)
    {
        //print(lifeTri.name);
        if (lifeTri.name == "PlayerCapsule" && Input.GetKey(KeyCode.LeftControl))
        {
            print("hello");
            canvas.GetComponent<PauseMenu>().invokedPanel3Open();
        }
    }
}
