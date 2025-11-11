using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stockGoUp : MonoBehaviour
{
    public drawLineToLastPeg drawLine;

    public GameObject stockPegPrefab;
    public GameObject canvas;

    public Transform stockPeg;
    private Transform previousPegTransform;
    public Transform startPegTransform;

    public int pegLimit = 5;
    public TMP_Text pegLimitText;

    public moneyManager moneyManager;

    void Start()
    {
        previousPegTransform = startPegTransform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pegLimit >= 1)
            {
                ChangeStockValue();
                pegLimit -= 1;
                pegLimitText.text = $"{pegLimit} day(s)";
            }
        }

        if (pegLimit == 0)
        {
            StartNewWeek();
        }
    }

    public void ChangeStockValue()
    {
        //pegs are UI elements so uses rect transform, sets the transform of the current and previous peg
        RectTransform stockPegRect = stockPeg.GetComponent<RectTransform>();
        RectTransform previousPegRect = previousPegTransform.GetComponent<RectTransform>();

        //sets the next peg forward and gives it a random y value that determines if the player makes or loses money
        float previousPegY = previousPegRect.anchoredPosition.y;
        float randomY = Random.Range(-200f, 200f);
        Vector2 newAnchoredPosition = stockPegRect.anchoredPosition + new Vector2(333f, randomY); //the peg is moved 333 forward on the x axis because in scene this makes it so the 5th created peg is at the edge of screen

        GameObject newPeg = Instantiate(stockPegPrefab, canvas.transform);
        RectTransform newPegRect = newPeg.GetComponent<RectTransform>();
        newPegRect.anchoredPosition = newAnchoredPosition;
        float newPegY = newPegRect.anchoredPosition.y;

        //sets the start and end points of new pegs draw line script to the new and previous pegs
        drawLine = newPeg.GetComponent<drawLineToLastPeg>();
        drawLine.startPoint = newPeg.transform;
        drawLine.endPoint = previousPegTransform;

        //calculates the percent change of the stock and updates the player's money
        float percentChange = (newPegY - previousPegY) / Mathf.Abs(previousPegY) * 100f;

        if (percentChange >= 0)
        {
            moneyManager.UpdateMoneyPositive(percentChange);
        }
        else
        {
            moneyManager.UpdateMoneyNegative(Mathf.Abs(percentChange));
        }

        previousPegTransform = newPeg.transform;
        stockPeg = newPeg.transform;
    }

    public void StartNewWeek()
    {
        if (moneyManager.money >= moneyManager.quota)
        {
            pegLimit = 5;
            moneyManager.quota *= 2;
            moneyManager.quotaText.text = $"quota: £{moneyManager.quota}";
            pegLimitText.text = $"{pegLimit} day(s)";
            moneyManager.SaveQuota();
        }
        else
        {
            Debug.Log("game over");
            moneyManager.ResetMoney();
            moneyManager.ResetQuota();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
