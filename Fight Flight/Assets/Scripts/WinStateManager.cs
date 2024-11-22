using UnityEngine;
using UnityEngine.SceneManagement;

public class WinStateManager : MonoBehaviour
{
    public GameObject winStatePanel;

    void Start()
    {
        winStatePanel.SetActive(false);
    }

    public void ShowWinState()
    {
        if (winStatePanel != null)
        {
            winStatePanel.SetActive(true);
        }
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Debug.Log("Restart button clicked");
        if (winStatePanel != null)
        {
            winStatePanel.SetActive(false);
        }
        GameManager.instance.RestartGame();
    }

    public void QuitGame()
    {
        Debug.Log("Quit button clicked");
        Application.Quit();
    }
}
