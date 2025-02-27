using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10f;          // Velocidad de movimiento
    public float mouseSensitivity = 100f;  // Sensibilidad del mouse

    private float xRotation = 0f;

    void Update()
    {
        // Movimiento con teclas WASD o flechas
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * horizontal + transform.forward * vertical;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Rotación con el mouse (solo al mantener clic derecho)
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
    }
}
