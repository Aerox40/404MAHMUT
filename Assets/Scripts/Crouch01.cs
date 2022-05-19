using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch01 : MonoBehaviour
{
    public CharacterController PlayerHeight;
    public float normalHeight, crouchHeight;
    private float distance;

    void Start()
    {
        distance = normalHeight-crouchHeight;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            PlayerHeight.height = crouchHeight;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) && PlayerHeight.height < normalHeight)
        {
            PlayerHeight.height = normalHeight;
            transform.position = new Vector3(transform.position.x, transform.position.y + (distance / 2), transform.position.z);
        }
    }
}
