using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverPanel;
    public HealthBar healthBar;
    public PointsSystem pointsSystem;

    private int maxHealth = 100;
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
        }
        else
        {
            Debug.LogError("HealthBar is not set in the Inspector");
        }

        if (pointsSystem == null)
        {
            Debug.LogError("PointsSystem is not set in the Inspector");
        }
    }

    public void GameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    public void AddPoints(int points)
    {
        pointsSystem.AddPoints(points);
    }
}

