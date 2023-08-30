using UnityEngine;

public class LadderAnimation : MonoBehaviour
{
    public Animator objectAnimator; // Reference to the Animator component.
    public string animationTrigger = "LadderSlide"; // Trigger for the animation.
    public float animationDuration = 1.3f; // Specify the duration of the animation in seconds.
    public GameObject replacementObjectPrefab; // Reference to the replacement object prefab.

    private bool animationStarted = false;
    private bool animationFinished = false;
    private float timer = 0f;

    public void LadderVoid()
    {
        // Trigger animation.
        objectAnimator.SetTrigger(animationTrigger);

        // Reset the timer and animation flags.
        timer = 0f;
        animationStarted = true;
        animationFinished = false;
    }

    private void Update()
    {
        if (animationStarted && !animationFinished)
        {
            // Increment the timer.
            timer += Time.deltaTime;

            // Check if the timer has exceeded the specified animation duration.
            if (timer >= animationDuration)
            {
                // Disable the Animator component.
                objectAnimator.enabled = false;

                // Instantiate the replacement object prefab.
                GameObject replacementObject = Instantiate(replacementObjectPrefab, transform.position, transform.rotation);
                replacementObject.SetActive(true);

                // Detach the replacement object from its parent.
                replacementObject.transform.SetParent(null);

                // Destroy the animated object.
                Destroy(gameObject);

                // Mark animation as finished.
                animationStarted = false;
                animationFinished = true;
            }
        }
    }
}


