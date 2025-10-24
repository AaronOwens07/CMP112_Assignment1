using UnityEngine;

public class drawLineToLastPeg : MonoBehaviour
{
    public Vector3 startPoint;
    public Vector3 endPoint;

    public GameObject mainCam;

    public LineRenderer lineRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");

        startPoint = transform.position;

        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);

        mainCam.transform.position += transform.forward * 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
