using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch01 : MonoBehaviour
{
    public CharacterController PlayerHeight;
    public float normalHeight, crouchHeight;
    private float distance;
    private bool isCrouched;

    void Start()
    {
        distance = normalHeight-crouchHeight;
    }

    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (!isCrouched)
            {
                PlayerHeight.height = crouchHeight;
                isCrouched = true;
            }
        }
        else if (isCrouched)
        {
            transform.position = new Vector3(transform.position.x, 5.2f, transform.position.z);
            PlayerHeight.height = normalHeight;
            isCrouched = false;
        }

    }
}
