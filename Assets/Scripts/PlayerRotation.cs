using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Transform characterBody;
    public float rotationSensitivity = 750f;
    float xRotation = 0f;
    [SerializeField] private float clampDegreeUp = 70f;
    private float clampDegreeDown = 0f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, clampDegreeDown, clampDegreeUp);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        characterBody.Rotate(Vector3.up * mouseX);
    }
}