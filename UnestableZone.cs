using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnestableZone : MonoBehaviour
{
    public float efectoInestabilidad = 2.0f; // Factor por el cual se multiplica la velocidad

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en el trigger es la pelota
        if (other.CompareTag("Pelota"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Aumenta la velocidad al entrar en la zona de inestabilidad
                rb.velocity *= efectoInestabilidad;
                Handheld.Vibrate();
                // También puedes agregar un efecto visual aquí si deseas
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si el objeto que sale del trigger es la pelota
        if (other.CompareTag("Pelota"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Restablece la velocidad al salir de la zona de inestabilidad
                rb.velocity /= efectoInestabilidad;
            }
        }
    }
}
