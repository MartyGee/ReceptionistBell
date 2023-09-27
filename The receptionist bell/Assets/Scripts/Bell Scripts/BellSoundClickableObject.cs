using UnityEngine;

public class BellSoundClickableObject : MonoBehaviour
{
    public AudioClip bellSound;
    public GameObject player;
    [Space]
    public int globalCounter;
    [Header("Animations to play on counter 10")]
    public LadderAnimation ladderAnimationScript;
    public WallLadderAnimation wallLadderAnimationScript;

    [Header("PaperSmooth1 spawn on counter 11")]
    public GameObject Paper1; // Reference to the prefab you want to instantiate

    [Header("PaperSmooth5 spawn on counter 12")]
    public GameObject Paper5;

    [Header("PaperSmooth5 spawn on counter 13")]
    public GameObject Paper7;

    private float thresholdDistance = 3f;

    

    private Vector3 originalPosition = new Vector3(0, 1.529f, 0);
    private Vector3 upsideDownPosition = new Vector3(0, 7.456f, 0);
    private Vector3 outsideTablePosition = new Vector3(20f, 20f, 20f);
    private Vector3 originalScale = new Vector3(2.5f, 2.5f, 2.5f);

    private Vector3 randomPosition;
    private Vector3 minBounds = new Vector3(7f, 1.529f, -7f);
    private Vector3 maxBounds = new Vector3(-7f, 1.529f, 7f);

    private Vector3 paperPosition = new Vector3(0, 0.509f, 0);

    private bool isObjectActivated = false; // Track if the object is activated

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
        globalCounter++;

        if (globalCounter == 7 || globalCounter == 8 || globalCounter == 9)
        {
            TeleportToRandomPosition();
        }
        else if (globalCounter == 10)
        {
            TeleportToUpsideDownPosition();
            ladderAnimationScript.LadderVoid();
            wallLadderAnimationScript.WallLadderVoid();
        }
        else if (globalCounter == 11)
        {
            if (!isObjectActivated)
            {
                // Activate the object (e.g., enable it)
                Paper1.SetActive(true);
                isObjectActivated = true;
            }
            TeleportToOutsidePosition();
            ResetToOriginalRotation();
        }
        else if (globalCounter == 12)
        {
            // Deactivate the object (e.g., disable it)
            gameObject.SetActive(false);
            ResetToOriginalPosition();
            ResetToOriginalScale();
            isObjectActivated = false;
            Paper5.SetActive(true);
        }
        else if (globalCounter == 13)
        {
            TeleportToOutsidePosition();
            Paper7.SetActive(true);
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
        transform.position = outsideTablePosition;
    }

    private void ResetToOriginalScale()
    {
        transform.localScale = originalScale;
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


