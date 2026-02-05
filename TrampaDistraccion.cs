using UnityEngine;

public class TrampaDistraccion : MonoBehaviour
{
    [Header("Configuración")]
    public AudioClip sonidoBurla; // Arrastra aquí la risa

    private bool activada = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activada)
        {
            activada = true;

            // 1. Generar el sonido en el aire (independiente de este objeto)
            if (sonidoBurla != null)
            {
                // Crea un objeto temporal en esta posición, reproduce el sonido y se autodestruye al terminar
                AudioSource.PlayClipAtPoint(sonidoBurla, transform.position);
            }

            // 2. Destruir la trampa INMEDIATAMENTE
            // Al usar PlayClipAtPoint, ya no necesitamos esperar.
            Destroy(gameObject);
        }
    }
}
