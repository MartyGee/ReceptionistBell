using UnityEngine;

public class NameShower : MonoBehaviour
{
    public GameObject instruction;
    private float interactionDistance = 3f;
    private bool isLookingAtObject = false;

    private void Start()
    {
        instruction.SetActive(false);
    }

    private void Update()
    {
        // Continuously check if the player is looking at the object.
        isLookingAtObject = CanInteractWithObject();

        // Display instruction when looking at the object.
        instruction.SetActive(isLookingAtObject);
    }

    private bool CanInteractWithObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            return hit.collider.gameObject == gameObject;
        }

        return false;
    }
}
