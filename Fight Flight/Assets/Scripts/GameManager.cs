using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverPanel;
    public HealthBar healthBar;
    public PointsSystem pointsSystem;
    public WinStateManager winStateManager;
    public GameObject healthBarUI;
    public GameObject pointsTextUI;

    private int maxHealth = 10;
    private int currentHealth;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("GameOverPanel is not set in the Inspector");
        }

        if (healthBar != null)
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(maxHealth); // Ensure health bar is set to max health
        }
        else
        {
            Debug.LogError("HealthBar is not set in the Inspector");
        }

        if (pointsSystem == null)
        {
            Debug.LogError("PointsSystem is not set in the Inspector");
        }

        if (winStateManager == null)
        {
            Debug.LogError("WinStateManager is not set in the Inspector");
        }

        if (healthBarUI == null)
        {
            Debug.LogError("HealthBarUI is not set in the Inspector");
        }

        if (pointsTextUI == null)
        {
            Debug.LogError("PointsTextUI is not set in the Inspector");
        }
    }

    public void GameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        healthBarUI.SetActive(false);
        pointsTextUI.SetActive(false);
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        Debug.Log("Quit button clicked");
        Application.Quit();
    }

    public void RestartGame()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        healthBarUI.SetActive(true);
        pointsTextUI.SetActive(true);
        Time.timeScale = 1f;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(maxHealth); // Ensure health bar is set to max health
        pointsSystem.ResetPoints();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took damage. Current health: " + currentHealth);
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            if (gameObject != null)
            {
                GameOver();
            }
        }
    }

    public void AddPoints(int points)
    {
        pointsSystem.AddPoints(points);

        if (pointsSystem.GetPoints() >= 200)
        {
            if (winStateManager != null)
            {
                winStateManager.ShowWinState();
            }
            else
            {
                Debug.LogError("WinStateManager is not set in the Inspector");
            }
        }
    }
}





