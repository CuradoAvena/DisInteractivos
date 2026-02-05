using UnityEngine;
using System.Collections;
public class AudioManager : MonoBehaviour
{
    [Header("Los Parlantes")]
    public AudioSource audioMeta;   // Arrastra aquí la Meta
    public AudioSource audioTrampa; // Arrastra aquí la Trampa

    [Header("Ritmo")]
    public float tiempoEntreTurnos = 1.5f; // Segundos de silencio entre uno y otro

    IEnumerator Start()
    {
        // Bucle infinito: Nunca deja de rodar mientras juegues
        while (true)
        {
            // --- TURNO 1: LA META ---
            if (audioMeta != null)
            {
                audioMeta.Play();
            }

            // Esperamos X segundos
            yield return new WaitForSeconds(tiempoEntreTurnos);

            // --- TURNO 2: LA TRAMPA ---
            // (Verificamos si existe, por si el jugador ya la destruyó)
            if (audioTrampa != null)
            {
                audioTrampa.Play();
            }

            // Esperamos otra vez antes de repetir
            yield return new WaitForSeconds(tiempoEntreTurnos);
        }
    }
}
