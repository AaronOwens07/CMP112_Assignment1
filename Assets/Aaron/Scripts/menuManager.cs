using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public Button slotButton;
    public Button stockButton;

    public string stockSceneName;
    public string slotSceneName;


    public void StockSelect()
    {
        SceneManager.LoadScene(stockSceneName);
    }

    public void SlotSelect()
    {
        SceneManager.LoadScene(slotSceneName);
    }

}
