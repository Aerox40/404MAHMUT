using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject panel1, panel2, panel3, panel4, panel5, panel6, lifetriangle, finishtriangle;

    public GameObject playerCapsule;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            StopMovement();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        StartMovement();
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        StopMovement();
        GameIsPaused = true;
    }

    void Start()
    {
        StopMovement();
    }

    public void Panel1Close()
    {
        panel1.SetActive(false);
        StartMovement();
    }

    private void StopMovement()
    {
        playerCapsule.GetComponent<CharacterController>().gameObject.SetActive(false);
        playerCapsule.GetComponent<Crouch01>().gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }

    private void StartMovement()
    {
        playerCapsule.GetComponent<CharacterController>().gameObject.SetActive(true);
        playerCapsule.GetComponent<Crouch01>().gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void invokedPanel2Open()
    {
        Invoke("panel2Open", 10f);
    }

    private void panel2Open()
    {
        panel2.SetActive(true);
        StopMovement();
    }

    public void panel2Close() 
    {
        panel2.SetActive(false);
        StartMovement();
        lifetriangle.SetActive(true);
    }

    public void invokedPanel3Open()
    {
        Invoke("lockcrouching", 1f);
        Invoke("panel3Open", 10f);     
    }

    private void panel3Open()
    {
        panel3.SetActive(true);
        StopMovement();
        Invoke("lockcrouching", 1f);
    }

    public void panel3Close()
    {
        panel3.SetActive(false);
        StartMovement();
    }

    private void lockcrouching()
    {
        playerCapsule.GetComponent<CharacterController>().gameObject.SetActive(false);
        playerCapsule.GetComponent<Crouch01>().gameObject.SetActive(false);
    }

    void panel4Open()
    {
        panel4.SetActive(true);
        StopMovement();
    }

    public void panel4Close()
    {
        panel4.SetActive(false);
        StartMovement();
        SelectionManager.lever2 = true;
    }
    public void invokedPanel4Open()
    {
        Invoke("panel4Open", 8.5f);
    }

    public void panel5Open()
    {
        panel5.SetActive(true);
        StopMovement();
    }

    public void panel5Close()
    {
        panel5.SetActive(false);
        StartMovement();
    }

    public void panel6Open()
    {
        panel6.SetActive(true);
        StopMovement();
    }
}
