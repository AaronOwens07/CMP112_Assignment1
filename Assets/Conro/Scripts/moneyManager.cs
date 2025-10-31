using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class moneyManager : MonoBehaviour
{
    public float money;
    public float moneyInMarket;

    public TMP_Text moneyText;
    public TMP_Text moneyInMarketText;
    public TMP_InputField investmentInput;

    void Start()
    {
        UpdateMoneyText();
    }

    void Update()
    {

    }

    public void UpdateMoney(float percent)
    {
        //multiplies player money by the amount the stock when up or down
        money += moneyInMarket * percent;
        moneyInMarket = 0;
        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        //sets the in-game money text to the money value, to 2 decimal places
        moneyText.text = $"£{money:F2}";
        moneyInMarketText.text = $"£ in stock: {moneyInMarket:F2}";
    }

    public void setInvestment()
    {
        moneyInMarket = float.Parse(investmentInput.text);

        if (moneyInMarket <= money)
        {
            money -= moneyInMarket;
            UpdateMoneyText();
            investmentInput.text = "";
        }
        else
        {
            investmentInput.text = "Not enough money!";
            moneyInMarket = 0;
        }
    }
}
