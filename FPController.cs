using UnityEngine;

public class FPController : MonoBehaviour
{
    [Header("Configuración")]
    public CharacterController controller;
    public float speed = 5f; // Ajusta esto si va muy lento/rápido
    public float gravity = -9.81f;

    [Header("Detección de Suelo")]
    public Transform groundCheck; // Arrastrarás aquí un objeto vacío que esté en los pies
    public float groundDistance = 0.4f;
    public LayerMask groundMask; // Qué capas cuentan como suelo

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        // 1. Verificar si tocamos el suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // RESET DE GRAVEDAD (Importante): Si estamos en el suelo, reseteamos la velocidad de caída
        // para que no se acumule infinitamente.
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // 2. Moverse (WASD)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Nos movemos en la dirección hacia donde mira el personaje
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // 3. Aplicar Gravedad (Sin salto)
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
