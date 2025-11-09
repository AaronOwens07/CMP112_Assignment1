using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TriggerBox : MonoBehaviour
{
    [Header("Selection + Movement Variables")]
    public GameObject selectionUI;
    public bool canTrigger;
    public bool isTriggered;
    public PlayerMovement playerMovement;
    public cameraMovement cameraMovement;
    public ArticleGenerator articleGenerator;

    [Header("Audio Variables")]

    public AudioClip onSound;
    public float lowPitchRange = 1.0f;
    public float highPitchRange = 1.5f;
    private AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (canTrigger && !isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.enabled = false;
            cameraMovement.enabled = false;
            UnityEngine.Cursor.lockState = CursorLockMode.Confined;
            Debug.Log("Locking");
            isTriggered = true;

            selectionUI.SetActive(true);
            articleGenerator.DisplayNewArticle();
            source.pitch = Random.Range(lowPitchRange, highPitchRange);
            source.Play();
        }
        else if(isTriggered &&  Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.enabled = true;
            cameraMovement.enabled = true;
            UnityEngine.Cursor.lockState = CursorLockMode.None;

            Debug.Log("UnLocking");
            isTriggered = false;
            selectionUI.SetActive(false);

            
        }
        

    }

    private void OnTriggerEnter(Collider other)
    { 
      
        if (other.gameObject.CompareTag("Player"))
        {
            canTrigger = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canTrigger = false;
        }
        

    }

}
