using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startSceneName;
    public void firstPlay()
    {
        SceneManager.LoadScene(startSceneName);
        Debug.Log("Start Game");
    }
}
