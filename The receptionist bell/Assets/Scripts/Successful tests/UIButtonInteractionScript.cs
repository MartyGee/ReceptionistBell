using UnityEngine;
using UnityEngine.UI;

public class UIButtonInteractionScript : MonoBehaviour
{
    public Transform objectToManipulate; // Reference to the object you want to manipulate
    public Button manipulateButton; // Reference to the UI button

    public Vector3 desiredPosition;
    public Vector3 desiredRotation;
    public Vector3 desiredScale;

    void Start()
    {
        // Assign the UI button click listener
        manipulateButton.onClick.AddListener(SetTransform);

        // Initialize the object's initial position, rotation, and scale
        desiredPosition = objectToManipulate.position;
        desiredRotation = objectToManipulate.rotation.eulerAngles;
        desiredScale = objectToManipulate.localScale;
    }

    public void SetTransform()
    {
        // Set the desired position, rotation, and scale when the button is clicked
        objectToManipulate.position = desiredPosition;
        objectToManipulate.rotation = Quaternion.Euler(desiredRotation);
        objectToManipulate.localScale = desiredScale;
    }
}