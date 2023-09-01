using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    [SerializeField] private LayerMask PickupMask;
    [SerializeField] private Camera PlayerCam;
    [SerializeField] private Transform PickupPoint;
    [Space]
    [SerializeField] private float PickupRange;

    // Add the IsInRange property
    public bool IsInRange
    {
        get; private set;
    }

    private Rigidbody CurrentObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CurrentObject)
            {
                CurrentObject.useGravity = true;
                CurrentObject = null;
                IsInRange = false; // Object is no longer in range when not picked up
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