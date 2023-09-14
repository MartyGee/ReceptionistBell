using UnityEngine;
using TMPro;
using System.Collections;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float totalTime = 300.0f; // 5 minutes in seconds
    private bool timerActive = false;
    private Color startColor = Color.white; // Initial color (white)
    private Color endColor = new Color(0.698f, 0.169f, 0.169f); // Color #B32B2B
    private float colorChangeDuration = 300.0f; // Time in seconds to transition from startColor to endColor

    void Start()
    {
        timerActive = true;
    }

    void Update()
    {
        if (timerActive)
        {
            totalTime -= Time.deltaTime;

            if (totalTime <= 0)
            {
                totalTime = 0;
                timerActive = false;
                StartCoroutine(BlinkTimerText());
            }

            UpdateTimerText();
            UpdateTimerColor();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(totalTime / 60);
        int seconds = Mathf.FloorToInt(totalTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void UpdateTimerColor()
    {
        // Calculate the current color based on the remaining time
        float t = 1.0f - (totalTime / colorChangeDuration);
        timerText.color = Color.Lerp(startColor, endColor, t);
    }

    IEnumerator BlinkTimerText()
    {
        int blinkCount = 9;
        WaitForSeconds blinkInterval = new WaitForSeconds(0.6f);

        while (blinkCount > 0)
        {
            timerText.enabled = !timerText.enabled;
            yield return blinkInterval;
            blinkCount--;
        }

        // After blinking, hide the timer text
        timerText.enabled = false;

        // Handle any additional actions or events here when the timer reaches 00:00
    }
}

