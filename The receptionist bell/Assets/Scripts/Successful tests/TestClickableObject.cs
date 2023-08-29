using UnityEngine;
using UnityEngine.Rendering;

public class TestClickableObject : MonoBehaviour
{
    public GameObject player;
    public float thresholdDistance = 5f;
    public Color normalColor = Color.white;
    public Color clickedColor = Color.red;
    private Renderer rend;
    private bool isKeyDown = false;

    public Animator objectAnimator1; // Reference to the Animator component.
    public Animator objectAnimator2; // Reference to the Animator component.
    public string animationTrigger1 = "WallSlide"; // Trigger for the first animation.
    public string animationTrigger2 = "LadderSlide"; // Trigger for the second animation.

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = normalColor;
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
                        rend.material.color = clickedColor;

                        objectAnimator1.SetTrigger(animationTrigger1);
                        objectAnimator2.SetTrigger(animationTrigger2);
                        isKeyDown = true;

                        
                    }
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.E) && isKeyDown)
        {
            rend.material.color = normalColor;
            isKeyDown = false;
        }
    }
}

//Questo script è solo un test per separare la funzione "oggetto interagibile" dallo script originale (BellSoundClickableObject).