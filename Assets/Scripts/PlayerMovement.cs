using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public bool canJump;
    float speed;
    public float walkSpeed = 2.5f;
    public float runSpeed = 5f;
    public float gravity = -9.81f;
    public float jumpForce = 1f;
    Vector3 velocity;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundDistance = 0.05f;
    public bool isGrounded;
    public TextMeshProUGUI victoryText;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (isGrounded && velocity.y < 0) velocity.y = -2f;

        if (Input.GetKey(KeyCode.LeftShift)) speed = runSpeed;
        else speed = walkSpeed;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded && canJump) velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit")) victoryText.gameObject.SetActive(true);
    }
}