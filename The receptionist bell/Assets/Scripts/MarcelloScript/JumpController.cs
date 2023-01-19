using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpHeight;
    public float jumpSpeed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpHeight * jumpSpeed);
        }

        if (rb.velocity.y > 0 && transform.position.y >= jumpHeight)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        }
    }
}
