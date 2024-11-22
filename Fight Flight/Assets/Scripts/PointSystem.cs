using UnityEngine;
using TMPro;

public class PointsSystem : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    private int points;

    void Start()
    {
        if (pointsText == null)
        {
            Debug.LogError("PointsText is not set in the Inspector");
            return;
        }

        points = 0;
        UpdatePointsText();
    }

    public void AddPoints(int amount)
    {
        points += amount;
        UpdatePointsText();
    }

    void UpdatePointsText()
    {
        if (pointsText != null)
        {
            pointsText.text = "Points: " + points.ToString();
        }
    }
}

