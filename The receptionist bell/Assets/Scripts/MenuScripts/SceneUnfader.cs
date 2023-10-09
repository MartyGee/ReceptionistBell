using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneUnfader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 1.0f;

    private bool isFading = false;
    private int targetSceneIndex;

    private void Start()
    {
        fadeImage.canvasRenderer.SetAlpha(0);
        fadeImage.raycastTarget = false; // Disable raycasting
    }

    public void FadeToScene(int sceneIndex)
    {
        targetSceneIndex = sceneIndex;
        isFading = true;
        fadeImage.raycastTarget = true; // Enable raycasting while fading
        fadeImage.CrossFadeAlpha(1, fadeSpeed, false);
    }

    private void Update()
    {
        if (isFading)
        {
            // Check if the fade out is complete
            if (fadeImage.canvasRenderer.GetAlpha() >= 1)
            {
                // Load the target scene
                SceneManager.LoadScene(targetSceneIndex);
            }
        }
    }
}
