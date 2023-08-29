using UnityEngine;

public class LadderAnimation : MonoBehaviour
{
    public Animator objectAnimator; // Reference to the Animator component.
    public string animationTrigger = "LadderSlide"; // Trigger for the second animation.
    public void LadderVoid()
    {
            // Trigger both animations.
            objectAnimator.SetTrigger(animationTrigger);
    }
}