using UnityEngine;
using TMPro;

public class PointsSystem : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    private int points;

    void Start()
    {
        points = 0;
        UpdatePointsText();
    }

    public void AddPoints(int amount)
    {
        points += amount;
        UpdatePointsText();
    }

    public int GetPoints()
    {
        return points;
    }

    public void ResetPoints()
    {
        points = 0;
        UpdatePointsText();
    }

    void UpdatePointsText()
    {
        pointsText.text = "Points: " + points.ToString();
    }
}


