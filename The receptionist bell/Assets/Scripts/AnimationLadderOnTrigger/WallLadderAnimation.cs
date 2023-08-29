using UnityEngine;

public class WallLadderAnimation : MonoBehaviour
{
    public Animator objectAnimator; // Reference to the Animator component.
    public string animationTrigger = "WallSlide"; // Trigger for the first animation.

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Trigger both animations.
            objectAnimator.SetTrigger(animationTrigger);
        }
    }
}