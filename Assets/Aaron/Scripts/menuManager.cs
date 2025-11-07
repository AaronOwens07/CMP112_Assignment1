using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public Button stockButton;
    public string stockSceneName;
    public GameObject videoClip;

    public GameObject newsite;

    public float time;

    private void Start()
    {
        
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > 3)
        {
        videoClip.SetActive(false);

        }
    }

    public void StockSelect()
    {
        SceneManager.LoadScene(stockSceneName);
    }

    public void openNews()
    {
        newsite.SetActive(true);
    }

    public void CloseNews()
    {
        newsite.SetActive(false);
    }

}
