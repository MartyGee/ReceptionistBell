using UnityEngine;

public class BellSoundClickableObject : MonoBehaviour
{
    public AudioClip bellSound;
    public AudioSource audioSource;
    public GameObject player;
    public float thresholdDistance = 5f;
    public Vector3 minBounds;
    public Vector3 maxBounds;
    public Vector3 originalPosition;
    private int counter = 0;
    public Vector3 randomPosition;
    public Vector3 upsideDownPosition = new Vector3 (0,7.456f,0);

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        originalPosition = transform.position;
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
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        audioSource.PlayOneShot(bellSound);
                        counter++;
                        if (counter >= 7 && counter < 8)
                        {
                            // Generate a random position within the defined bounds
                            randomPosition = new Vector3
                                (Random.Range(minBounds.x, maxBounds.x),
                                 Random.Range(minBounds.y, maxBounds.y),
                                 Random.Range(minBounds.z, maxBounds.z));

                            // Teleport the object to the new position
                            transform.position = randomPosition;
                        }

                        else if (counter >= 13 && counter < 14)
                        {
                            // Generate a random position within the defined bounds
                            randomPosition = new Vector3
                                (Random.Range(minBounds.x, maxBounds.x),
                                 Random.Range(minBounds.y, maxBounds.y),
                                 Random.Range(minBounds.z, maxBounds.z));

                            // Teleport the object to the new position
                            transform.position = randomPosition;
                        }

                        else if (counter >= 19 && counter < 20)
                        {
                            // Teleport the object to the new position
                            Quaternion upsideDownRotation = Quaternion.Euler(90,90,-90);
                            transform.rotation = upsideDownRotation;
                            transform.position = upsideDownPosition;
                        }

                        else if (counter == 20)
                        {
                            Quaternion originalRotation = Quaternion.Euler(-90, 90, -90);
                            transform.rotation = originalRotation;
                            transform.position = originalPosition;      
                        }
                    }
                }
            }
        }
    }
}