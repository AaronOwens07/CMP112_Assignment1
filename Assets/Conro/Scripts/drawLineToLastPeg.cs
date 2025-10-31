using UnityEngine;

public class drawLineToLastPeg : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    public GameObject mainCam;
    public LineRenderer lineRenderer;

    void Start()
    {
        //don't use find, im using it because im stupid on the occasion
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");

        lineRenderer.SetPosition(0, startPoint.position);
        lineRenderer.SetPosition(1, endPoint.position);

        mainCam.transform.position += transform.forward * 0.01f;
    }

    void Update()
    {

    }
}
