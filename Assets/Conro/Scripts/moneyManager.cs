using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class moneyManager : MonoBehaviour
{
    public float money;
    public float moneyInMarket;

    public float lowPitchRange = 0.8f;
    public float highPitchRange = 1.2f;

    public TMP_Text moneyText;
    public TMP_Text moneyInMarketText;
    public TMP_InputField investmentInput;

    public AudioSource moneyAudioSource;
    public AudioClip moneyChangeAudioClip;

    void Start()
    {
        UpdateMoneyText();
    }

    void Update()
    {

    }

    public void UpdateMoneyPositive(float percent)
    {
        //multiplies player money by the amount the stock went up
        percent = 1+(percent/100);
        Debug.Log(percent);
        moneyInMarket *= percent;
        money += moneyInMarket;

        moneyInMarket = 0;
        UpdateMoneyText();

        moneyAudioSource.PlayOneShot(moneyChangeAudioClip, 1.0f);
        moneyAudioSource.pitch = Random.Range(lowPitchRange, highPitchRange);
    }

    public void UpdateMoneyNegative(float percent)
    {
        //same thing but decrease
        percent = 0+(percent/100);
        Debug.Log(percent);
        moneyInMarket *= percent;
        money += moneyInMarket;

        moneyInMarket = 0;
        UpdateMoneyText();

        moneyAudioSource.PlayOneShot(moneyChangeAudioClip, 1.0f);
        moneyAudioSource.pitch = Random.Range(lowPitchRange, highPitchRange);
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
