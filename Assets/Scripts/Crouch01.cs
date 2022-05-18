using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch01 : MonoBehaviour
{
    public CharacterController PlayerHeight;
    public float normalHeight, crouchHeight;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            PlayerHeight.height = crouchHeight;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            PlayerHeight.height = normalHeight;
        }
    }
}
