using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPelota : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 initialPosition;

    void Start()
    {
        // Guarda la posición inicial de la pelota
        initialPosition = transform.position;

        // Obtiene el componente Rigidbody
        rb = GetComponent<Rigidbody>();

        // Asegúrate de que el giroscopio esté habilitado en el dispositivo
        if (!SystemInfo.supportsGyroscope)
        {
            Debug.LogError("Este dispositivo no soporta giroscopio");
        }
        else
        {
            // Habilita el giroscopio
            Input.gyro.enabled = true;
        }
    }

    void Update()
    {
        // Obtener los datos del giroscopio y aplicarlos al Rigidbody
        Vector3 tilt = Input.gyro.gravity;

        // Aplicar fuerza al Rigidbody en función de la inclinación del dispositivo
        rb.AddForce(new Vector3(tilt.x, 0, tilt.y) * 10f); // Ajusta el factor de fuerza según sea necesario
    }

    // Método que detecta cuando la pelota entra en contacto con una trampa
    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que colisiona es una trampa
        if (other.gameObject.CompareTag("Trampa"))
        {
            // Reinicia la posición de la pelota a su posición inicial
            transform.position = initialPosition;

            // Reinicia la velocidad de la pelota para evitar que siga moviéndose
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
