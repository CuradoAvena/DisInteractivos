using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody; // Arrastra aquí al objeto PADRE (el jugador)

    float xRotation = 0f;

    void Start()
    {
        // Oculta y bloquea el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Obtenemos el movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotación vertical (Mirar arriba/abajo) con límites
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // No puedes romperte el cuello

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotación horizontal (Girar el cuerpo entero del personaje)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

