using UnityEngine;

public class drawLineToLastPeg : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    public GameObject mainCam;
    public LineRenderer lineRenderer;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");

        lineRenderer.SetPosition(0, startPoint.position);
        lineRenderer.SetPosition(1, endPoint.position);

        mainCam.transform.position += transform.forward * 0.01f;
    }

    void Update()
    {

    }
}
