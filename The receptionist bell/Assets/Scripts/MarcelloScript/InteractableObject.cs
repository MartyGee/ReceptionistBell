using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    #region Variables & Properties

    [SerializeField] private float thresholdDistance = 5f;

    #endregion

    #region MonoBehaviour

    // Awake is called when the script instance is being loaded
    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && VerifyDistance())
        {
            OnInteract();
        }
    }

    #endregion

    #region Methods

    private bool VerifyDistance()
    {
        float distance = Vector3.Distance(Player.Instance.transform.position, transform.position);
        if (distance < thresholdDistance)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    return true;
                }
            }
        }
        return false;
    }

        protected virtual void OnInteract()
        {
            
        }

    #endregion

}