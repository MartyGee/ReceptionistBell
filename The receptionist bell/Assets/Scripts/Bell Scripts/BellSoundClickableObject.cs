using UnityEngine;

public class BellSoundClickableObject : MonoBehaviour
{
    public AudioClip bellSound;
    public GameObject player;
    public GameObject objectPrefab; // Reference to the prefab you want to instantiate
    private float thresholdDistance = 3f;

    private int counter = 0;
    private Vector3 minBounds = new Vector3(7f, 1.529f, -7f);
    private Vector3 maxBounds = new Vector3(-7f, 1.529f, 7f);
    private Vector3 originalPosition = new Vector3(0, 1.529f, 0);
    private Vector3 randomPosition;
    private Vector3 upsideDownPosition = new Vector3(0, 7.456f, 0);
    private Vector3 paperPosition = new Vector3(0, 0.509f, 0);
    private Vector3 newTablePosition = new Vector3(20f, 20f, 20f);

    [Header("Animations to play")]
    public LadderAnimation ladderAnimationScript;
    public WallLadderAnimation wallLadderAnimationScript;

    private void Start()
    {
        originalPosition = transform.position;

        // Make sure bellSound is assigned
        if (bellSound == null)
        {
            Debug.LogError("Bell sound is not assigned!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance < thresholdDistance)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
                {
                    RingBell();
                }
            }
        }
    }

    private void RingBell()
    {
        AudioSource.PlayClipAtPoint(bellSound, transform.position);
        counter++;

        if (counter == 7 || counter == 8 || counter == 9)
        {
            TeleportToRandomPosition();
        }
        else if (counter == 10)
        {
            TeleportToUpsideDownPosition();
            ladderAnimationScript.LadderVoid();
            wallLadderAnimationScript.WallLadderVoid();
        }
        else if (counter == 11)
        {
            // Spawn the object prefab at the original position with a specific rotation
            spawnObject();
            TeleportToOutsidePosition();
            ResetToOriginalRotation();
        }
    }

    private void TeleportToRandomPosition()
    {
        randomPosition = new Vector3(
            Random.Range(minBounds.x, maxBounds.x),
            Random.Range(minBounds.y, maxBounds.y),
            Random.Range(minBounds.z, maxBounds.z));

        transform.position = randomPosition;
    }

    private void TeleportToUpsideDownPosition()
    {
        Quaternion upsideDownRotation = Quaternion.Euler(90, 90, -90);
        transform.rotation = upsideDownRotation;
        transform.position = upsideDownPosition;
    }

    private void ResetToOriginalPosition()
    {
        Quaternion originalRotation = Quaternion.Euler(-90, 90, -90);
        transform.rotation = originalRotation;
        transform.position = originalPosition;
    }

    private void ResetToOriginalRotation()
    {
        Quaternion originalRotation = Quaternion.Euler(-90, 90, -90);
        transform.rotation = originalRotation;
    }

    private void TeleportToOutsidePosition()
    {
        transform.position = newTablePosition;
    }

    private void spawnObject()
    {
        // Create a Quaternion representing the desired rotation (e.g., 90 degrees around the X-axis)
        Quaternion paperRotation = Quaternion.Euler(-90, 180, 0);

        // Instantiate the object prefab at the paperPosition with the desired rotation
        Instantiate(objectPrefab, paperPosition, paperRotation);

        // Optionally, you can do something with the spawned object, such as setting its properties or adding it to a list.
        // For example, you can access its components like this:
        // MyComponentType component = spawnedObject.GetComponent<MyComponentType>();
    }

    // Add a new method to detect collision with the object being moved
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovableObjectTag"))
        {
            // Ring the bell when a movable object collides with it
            RingBell();
        }
    }
}

