using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class moneyManager : MonoBehaviour
{
    public float money;
    public float quota;
    public float moneyInMarket;

    public float lowMoneyPitchRangeLow = 0.85f;
    public float lowMoneyPitchRangeHigh = 0.99f;
    public float highMoneyPitchRangeLow = 1.01f;
    public float highMoneyPitchRangeHigh = 1.15f;

    public TMP_Text moneyText;
    public TMP_Text moneyInMarketText;
    public TMP_InputField investmentInput;
    public TMP_Text quotaText;

    public AudioSource moneyAudioSource;
    public AudioClip moneyChangeAudioClip;

    void Start()
    {
        money = PlayerPrefs.GetFloat("PlayerMoney", money);
        LoadQuota();
        UpdateMoneyText();
        quotaText.text = $"quota: £{quota}";
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
        SaveMoney();

        moneyAudioSource.pitch = Random.Range(highMoneyPitchRangeLow, highMoneyPitchRangeHigh);
        moneyAudioSource.PlayOneShot(moneyChangeAudioClip, 1.0f);
    }

    public void UpdateMoneyNegative(float percent)
    {
        //percent is positive, so convert to a reduction
        percent = 1 - (percent / 100f);
        moneyInMarket *= percent;

        //the player gets instant bankrupted if the stock decreases by over 100% so you need this
        if (moneyInMarket < 0)
        {
            moneyInMarket = 0;
        }

        money += moneyInMarket;

        moneyInMarket = 0;
        UpdateMoneyText();
        SaveMoney();

        moneyAudioSource.pitch = Random.Range(lowMoneyPitchRangeLow, lowMoneyPitchRangeHigh);
        moneyAudioSource.PlayOneShot(moneyChangeAudioClip, 1.0f);
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
            SaveMoney();
            investmentInput.text = "";
        }
        else
        {
            investmentInput.text = "Not enough money!";
            moneyInMarket = 0;
        }
    }

    public void SaveMoney()
    {
        //saves players money amount across scenes (e.g. if they exit computer and re-enter)
        PlayerPrefs.SetFloat("PlayerMoney", money);
        PlayerPrefs.Save();
    }

    public void SaveQuota()
    {
        PlayerPrefs.SetFloat("PlayerQuota", quota);
        PlayerPrefs.Save();
    }

    public void LoadQuota()
    {
        quota = PlayerPrefs.GetFloat("PlayerQuota", quota);
    }

    public void ResetMoney()
    {
        money = 100;
        SaveMoney();
        UpdateMoneyText();
    }

    public void ResetQuota()
    {
        quota = 300;
        SaveQuota();
        quotaText.text = $"quota: £{quota}";
    }
}
