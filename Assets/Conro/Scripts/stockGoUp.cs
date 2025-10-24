using UnityEngine;

public class stockGoUp : MonoBehaviour
{
    public drawLineToLastPeg drawLine;
    public GameObject stockPegPrefab;
    public Vector3 stockPeg;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeStockValue();
        }
    }

    public void ChangeStockValue()
    {
        Vector3 newStockPeg = stockPeg + new Vector3(300, 0, 0);
        GameObject newPeg = Instantiate(stockPegPrefab, newStockPeg, stockPegPrefab.transform.rotation);

        drawLine = newPeg.GetComponent<drawLineToLastPeg>();
        drawLine.endPoint = newStockPeg;

        stockPeg = newStockPeg;
    }
}
