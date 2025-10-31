using UnityEngine;
using TMPro;

public class moneyManager : MonoBehaviour
{
    public float money;
    public TMP_Text moneyText;

    void Start()
    {
        UpdateMoneyText();
    }

    void Update()
    {
    }

    public void UpdateMoney(float percent)
    {
        money += money * percent;
        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        // sets the in-game money text to the money value, to 2 decimal places
        moneyText.text = $"${money:F2}";
    }
}
