using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene to load.

    private void Start()
    {
        // Attach a listener to the button's onClick event.
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ChangeScene);
        }
    }

    void ChangeScene()
    {
        // Load the specified scene.
        SceneManager.LoadScene(sceneToLoad);
    }
}
