using UnityEngine;

public class BellSoundClickableObject : MonoBehaviour
{
    public AudioClip bellSound;
    public GameObject player;
    //space
    public float thresholdDistance = 5f;
    //space
    private Vector3 minBounds = new Vector3(7f, 1.529f, -7f);
    private Vector3 maxBounds = new Vector3(-7f, 1.529f, 7f);
    private Vector3 originalPosition= new Vector3(0, 1.529f, 0);
    //space
    private int counter = 0;
    //space
    private Vector3 randomPosition;
    private Vector3 upsideDownPosition = new Vector3(0, 7.456f, 0);
    //space
    public LadderAnimation ladderAnimationScript;
    public WallLadderAnimation wallLadderAnimationScript;

    void Start()
    {
        originalPosition = transform.position;

        // Make sure bellSound is assigned
        if (bellSound == null)
        {
            Debug.LogError("Bell sound is not assigned!");
        }
    }

    void Update()
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
                    AudioSource.PlayClipAtPoint(bellSound, transform.position);
                    counter++;

                    if (counter == 7 | counter == 8 | counter == 9 ) 
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
                        ResetToOriginalPosition();
                    }
                }
            }
        }
    }

    void TeleportToRandomPosition()
    {
        randomPosition = new Vector3(
            Random.Range(minBounds.x, maxBounds.x),
            Random.Range(minBounds.y, maxBounds.y),
            Random.Range(minBounds.z, maxBounds.z));

        transform.position = randomPosition;
    }

    void TeleportToUpsideDownPosition()
    {
        Quaternion upsideDownRotation = Quaternion.Euler(90, 90, -90);
        transform.rotation = upsideDownRotation;
        transform.position = upsideDownPosition;
    }

    void ResetToOriginalPosition()
    {
        Quaternion originalRotation = Quaternion.Euler(-90, 90, -90);
        transform.rotation = originalRotation;
        transform.position = originalPosition;
    }
}