using UnityEngine;
using UnityEngine.UI;

public class SoundOnButtonClick : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // Find the Button component and add a listener to call PlaySound when clicked
        Button button = GetComponent<Button>();
        button.onClick.AddListener(PlaySound);
    }

    void PlaySound()
    {
        // Play the sound
        audioSource.Play();
    }
}
