using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    [SerializeField] private LayerMask PickupMask;
    [SerializeField] private Camera PlayerCam;
    [SerializeField] private Transform PickupPoint;
    [Space]
    [SerializeField] private float PickupRange;
    [SerializeField] private float ScrollSpeed = 0.1f; // Speed of scrolling to adjust pickup distance
    [SerializeField] private float MinDistance = 1f;    // Minimum pickup distance
    [SerializeField] private float MaxDistance = 10f;   // Maximum pickup distance

    private float initialDistance; // Initial pickup distance
    private Vector3 initialPickupPointPosition; // Initial position of PickupPoint
    private float currentDistance; // Current pickup distance

    // Add the IsInRange property
    public bool IsInRange { get; private set; }

    private Rigidbody CurrentObject;

    private void Start()
    {
        initialPickupPointPosition = PickupPoint.position;
        initialDistance = PickupRange; // Set the initial pickup distance to the PickupRange value
        currentDistance = initialDistance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CurrentObject)
            {
                CurrentObject.useGravity = true;
                CurrentObject = null;
                IsInRange = false; // Object is no longer in range when not picked up
                currentDistance = initialDistance; // Reset the currentDistance to the initialDistance
                return;
            }

            Ray CameraRay = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
            {
                CurrentObject = HitInfo.rigidbody;
                CurrentObject.useGravity = false;
                IsInRange = true; // Object is in range and can be picked up
            }
            else
            {
                IsInRange = false; // Object is not in range
            }
        }

        // Handle scrolling to adjust pickup distance (invert the controls)
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0)
        {
            // Invert the scroll input and adjust the pickup distance within the specified range
            currentDistance = Mathf.Clamp(currentDistance + scrollInput * ScrollSpeed, MinDistance, MaxDistance);
        }

        // Update the position of PickupPoint based on the currentDistance
        Vector3 newPickupPointPosition = PlayerCam.transform.position + PlayerCam.transform.forward * currentDistance;
        PickupPoint.position = newPickupPointPosition;
    }

    void FixedUpdate()
    {
        if (CurrentObject)
        {
            Vector3 DirectionToPoint = PickupPoint.position - CurrentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            CurrentObject.velocity = 2f * DistanceToPoint * DirectionToPoint;
        }
    }
}
