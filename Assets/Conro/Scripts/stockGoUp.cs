using UnityEngine;

public class stockGoUp : MonoBehaviour
{
    public drawLineToLastPeg drawLine;
    public GameObject stockPegPrefab;
    public Transform stockPeg;
    public GameObject canvas;
    private Transform previousPegTransform;
    public Transform startPegTransform;

    public moneyManager moneyManager;

    void Start()
    {
        previousPegTransform = startPegTransform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeStockValue();
        }
    }

    public void ChangeStockValue()
    {
        RectTransform stockPegRect = stockPeg.GetComponent<RectTransform>();
        RectTransform previousPegRect = previousPegTransform.GetComponent<RectTransform>();

        float previousPegY = previousPegRect.anchoredPosition.y;
        float randomY = Random.Range(-200f, 200f);
        Vector2 newAnchoredPosition = stockPegRect.anchoredPosition + new Vector2(333f, randomY);

        GameObject newPeg = Instantiate(stockPegPrefab, canvas.transform);
        RectTransform newPegRect = newPeg.GetComponent<RectTransform>();
        newPegRect.anchoredPosition = newAnchoredPosition;

        drawLine = newPeg.GetComponent<drawLineToLastPeg>();
        drawLine.startPoint = newPeg.transform;
        drawLine.endPoint = previousPegTransform;

        // calculates the percent change of the stock and updates the player's money
        float percentChange = (randomY / previousPegY);
        moneyManager.UpdateMoney(percentChange);

        previousPegTransform = newPeg.transform;
        stockPeg = newPeg.transform;
    }
}
