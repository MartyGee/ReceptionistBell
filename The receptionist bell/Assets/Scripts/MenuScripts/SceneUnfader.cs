using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneUnfader : MonoBehaviour
{
    public Image fadeOverlay;
    public float fadeDuration = 1.0f;
    public float initialDelay = 2.5f; // Delay before the initial fade from black
    public float delayBeforeFade = 5.0f; // Delay before the final fade to black
    public string sceneToLoad = "YourNextSceneName";

    private IEnumerator Start()
    {
        // Initial delay before the first fade from black
        yield return new WaitForSeconds(initialDelay);

        // Fade from black
        yield return FadeFromBlack();

        // Delay before fading to black again
        yield return new WaitForSeconds(delayBeforeFade);

        // Fade to black
        yield return FadeToBlack();

        // Load the next scene
        SceneManager.LoadScene(sceneToLoad);
    }

    private IEnumerator FadeFromBlack()
    {
        Color initialColor = fadeOverlay.color;
        Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0f);

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            fadeOverlay.color = Color.Lerp(initialColor, targetColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the fade is complete by setting alpha to 0 explicitly
        fadeOverlay.color = targetColor;
    }

    private IEnumerator FadeToBlack()
    {
        Color initialColor = fadeOverlay.color;
        Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 1f);

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            fadeOverlay.color = Color.Lerp(initialColor, targetColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the fade is complete by setting alpha to 1 explicitly
        fadeOverlay.color = targetColor;
    }
}



