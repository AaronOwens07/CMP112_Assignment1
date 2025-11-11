using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    public float mouseSens;
    public Transform playerBody;

    float xRotation;
    public float maxRotation1;
    public float maxRotation2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        //Calculate rotation and clamp it
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, maxRotation1, maxRotation2);

        //Apply rotation to camera and player body
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
