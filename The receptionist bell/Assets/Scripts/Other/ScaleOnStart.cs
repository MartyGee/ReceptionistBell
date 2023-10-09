using UnityEngine;

public class ScaleOnStart : MonoBehaviour
{
    public float targetScaleX = 2.0f; // The target scale on the X-axis.
    public float targetScaleY = 2.0f; // The target scale on the Y-axis.
    public float duration = 10.0f; // The duration in seconds for the scaling process.

    private float currentTime = 0.0f;
    private Vector3 initialScale;

    private void Start()
    {
        // Store the initial scale of the object.
        initialScale = transform.localScale;
    }

    private void Update()
    {
        // Increment the timer.
        currentTime += Time.deltaTime;

        if (currentTime <= duration)
        {
            // Calculate the progress using an ease-out quadratic function.
            float progress = 1 - Mathf.Pow(1 - (currentTime / duration), 2);

            // Interpolate the new scale.
            float newScaleX = Mathf.Lerp(initialScale.x, targetScaleX, progress);
            float newScaleY = Mathf.Lerp(initialScale.y, targetScaleY, progress);

            // Apply the new scale to the object.
            transform.localScale = new Vector3(newScaleX, newScaleY, transform.localScale.z);
        }
    }
}
