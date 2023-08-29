using UnityEngine;

public class LadderAnimation : MonoBehaviour
{
    public Animator objectAnimator; // Reference to the Animator component.
    public string animationTrigger = "LadderSlide"; // Trigger for the second animation.

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Trigger both animations.
            objectAnimator.SetTrigger(animationTrigger);
        }
    }
}