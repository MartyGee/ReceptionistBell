using UnityEngine;
using UnityEngine.UI;

public class UIButtonInteractionScript : MonoBehaviour
{
    public Transform objectToManipulate; // Reference to the object you want to manipulate
    public Button manipulateButton; // Reference to the UI button

    public Vector3 desiredPosition = new Vector3(0f, 0f, 0f);
    public Vector3 desiredRotation = new Vector3(0f, 0f, 0f); // Initial rotation, you can change this
    public Vector3 desiredScale = new Vector3(0f, 0f, 0f);

    void Start()
    {
        // Assign the UI button click listener
        manipulateButton.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        // Set the desired position, rotation, and scale when the button is clicked
        objectToManipulate.position = desiredPosition;
        objectToManipulate.localRotation = Quaternion.Euler(desiredRotation);
        objectToManipulate.localScale = desiredScale;
    }
}
