using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public PlayerMovement playerMovement;
    public cameraMovement cameraMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);

            if(pauseMenuUI.activeSelf)
            {
                // Pause the game
                playerMovement.enabled = false;
                cameraMovement.enabled = false;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                // Resume the game
                playerMovement.enabled = true;
                cameraMovement.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        playerMovement.enabled = true;
        cameraMovement.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Quit()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

}
