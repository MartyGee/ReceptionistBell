using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public AudioClip bellSound;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    if (audioSource) audioSource.PlayOneShot(bellSound);
                }
            }
        }
    }
}

//Questo script è solo un test per separare il campanello dallo script originale (BellSoundClickableObject).