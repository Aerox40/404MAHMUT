using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject panel1, panel2, panel3, panel4, panel5, lifetriangle;

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
        //Time.timeScale = 1f;
        StartMovement();
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        //Time.timeScale = 0f;
        StopMovement();
        GameIsPaused = true;
    }

    void Start()
    {
        //Cursor.lockState = CursorLockMode.None;
        //Time.timeScale = 0f;
        StopMovement();
    }

    public void Panel1Close()
    {
        panel1.SetActive(false);
        //Time.timeScale = 1f;
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
}
