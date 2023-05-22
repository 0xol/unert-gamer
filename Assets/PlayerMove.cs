using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float gravity = 9.8f; // Adjust the gravity strength as needed
    public float movementSpeed = 5f; // Adjust the movement speed as needed

    private Rigidbody rb;
    private bool grounded = false; // Assume player starts not grounded

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        bool isJumping = Input.GetButton("Jump");

        Debug.Log("Horizontal Input: " + x);
        Debug.Log("Vertical Input: " + y);

        rb.position += new Vector3(x, 0 ,y);

        if (isJumping && grounded)
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(gravity * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            grounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
