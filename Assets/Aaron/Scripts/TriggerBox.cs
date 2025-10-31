using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerBox : MonoBehaviour
{

    public GameObject selectionUI;
    public bool canTrigger;
    public PlayerMovement playerMovement;
    public cameraMovement cameraMovement;

    private void Update()
    {
        if (canTrigger && Input.GetKey(KeyCode.E))
        {
            selectionUI.SetActive(true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canTrigger = true;
        }

        //turn Off Movement to access UI
        playerMovement.enabled = false;
        cameraMovement.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canTrigger = false;
        }
        

    }

}
