using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public float smoothSpeed = 0.1f; // Speed of the smooth transition

    public void SetMaxHealth(int health)
    {
        if (slider == null)
        {
            Debug.LogError("Slider is not set in the Inspector");
            return;
        }

        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        if (slider != null)
        {
            StartCoroutine(SmoothHealthChange(health));
        }
    }

    private IEnumerator SmoothHealthChange(int targetHealth)
    {
        float currentHealth = slider.value;
        float elapsedTime = 0f;

        while (elapsedTime < smoothSpeed)
        {
            slider.value = Mathf.Lerp(currentHealth, targetHealth, elapsedTime / smoothSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        slider.value = targetHealth;
    }
}

