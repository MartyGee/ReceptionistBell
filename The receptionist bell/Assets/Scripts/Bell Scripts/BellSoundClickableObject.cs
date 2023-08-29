using UnityEngine;

public class BellSoundClickableObject : MonoBehaviour
{
    public AudioClip bellSound;
    public GameObject player;

    public float thresholdDistance = 5f;

    public Vector3 minBounds;
    public Vector3 maxBounds;
    public Vector3 originalPosition;

    private int counter = 0;

    public Vector3 randomPosition;
    public Vector3 upsideDownPosition = new Vector3(0, 7.456f, 0);

    public Animator objectAnimator; // Reference to the Animator component.
    public string animationTrigger1 = "LadderSlide"; // Trigger for the second animation.
    public string animationTrigger2 = "WallSlide"; // Trigger for the first animation.

    public LadderAnimation ladderAnimationScript;
    public WallLadderAnimation WallladderAnimationScript;

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
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        // Play the bell sound at the object's position
                        AudioSource.PlayClipAtPoint(bellSound, transform.position);
                        counter++;

                        if ((counter >= 7 && counter < 8) ||
                            (counter >= 13 && counter < 14))
                        {
                            TeleportToRandomPosition();
                        }

                        if (counter == 19)
                        { 
                            TeleportToUpsideDownPosition();
                            //objectAnimator.SetTrigger(animationTrigger1);
                            //objectAnimator.SetTrigger(animationTrigger2);
                            ladderAnimationScript.Update();
                            WallladderAnimationScript.WallLadderVoid();

                        }
                        else if (counter == 20)
                        {
                            ResetToOriginalPosition();
                        }
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