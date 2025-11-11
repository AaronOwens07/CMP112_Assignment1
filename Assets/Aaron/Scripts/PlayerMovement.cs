using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;
    public Vector3 movement;
    public Transform camTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input axes
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // get camera directions
        Vector3 camForward = camTransform.forward;
        Vector3 camRight = camTransform.right;

        // combine inputs with camera directions
        movement = (camForward * vertical + camRight * horizontal ).normalized;
    }

    private void FixedUpdate()
    {
        // set velocity based on movement input
        Vector3 targetVelocity = movement * speed;
        rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);

    }


}
