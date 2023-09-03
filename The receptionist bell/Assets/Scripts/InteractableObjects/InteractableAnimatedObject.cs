using UnityEngine;

public class InteractableAnimatedObject : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject AnimeObject;
    public GameObject ThisTrigger;
    public AudioSource Sound;
    public bool Action = false;

    public GameObject objectToDestroy;

    void Start()
    {
        Instruction.SetActive(false);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))  // Use CompareTag for efficiency
        {
            Instruction.SetActive(true);
            Action = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        Instruction.SetActive(false);
        Action = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action)
            {
                Instruction.SetActive(false);
                AnimeObject.GetComponent<Animator>().Play("DoorAnim");
                ThisTrigger.SetActive(false);
                Sound.Play();

                // Check if objectToDestroy is not null before attempting to destroy it
                if (objectToDestroy != null)
                {
                    Destroy(objectToDestroy);
                }

                Action = false;
            }
        }
    }
}