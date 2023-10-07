using UnityEngine;
using UnityEngine.UI;

public class UIButtonInteractionScript : MonoBehaviour
{
    [Header("Animations to play")]
    public Animator objectAnimator1; // Reference to the Animator component for object 1
    public Animator objectAnimator2; // Reference to the Animator component for object 2

    public AudioSource buttonSound; // Reference to the AudioSource component for the button sound

    private bool animationsPlayed = false;

    void Start()
    {
        // You can remove the UI button click listener setup if it's not needed for other purposes.
    }

    public void PlayAnimations()
    {
        if (!animationsPlayed)
        {
            // Play the animations based on conditions immediately
            objectAnimator1.SetTrigger("OnEnter");
            objectAnimator2.SetTrigger("IsOpen");

            // Play the button sound
            buttonSound.Play();

            animationsPlayed = true;
        }
    }
}