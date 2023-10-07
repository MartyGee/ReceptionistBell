using UnityEngine;

public class WallLadderAnimation : MonoBehaviour
{
    public Animator objectAnimator; // Reference to the Animator component.
    public string animationTrigger = "WallSlide"; // Trigger for the first animation.

    public void WallLadderVoid()
    {
            // Trigger both animations.
            objectAnimator.SetTrigger(animationTrigger); 
    }
}