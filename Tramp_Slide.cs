using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tramp_Slide : MonoBehaviour
{
    public float alturaEmergencia = 1.0f; // Altura a la que emergen los picos
    public float tiempoEmergencia = 0.5f;  // Tiempo que tarda en emerger
    public float tiempoBajo = 1.0f;         // Tiempo que permanecen arriba antes de volver a esconderse

    private Vector3 posicionOriginal;       // Posición original de los picos
    private bool activado = false;          // Controla si los picos están activos

    private void Start()
    {
        // Guarda la posición original
        posicionOriginal = transform.localPosition;
    }

    public void EmergerPicos()
    {
        if (!activado)
        {
            activado = true; // Marca que los picos están activados
            StartCoroutine(Emerger()); // Llama a la rutina de emergencia
        }
    }

    private IEnumerator Emerger()
    {
        // Mueve los picos hacia arriba
        float tiempoTranscurrido = 0f;
        Vector3 posicionObjetivo = posicionOriginal + new Vector3(0, alturaEmergencia, 0);

        while (tiempoTranscurrido < tiempoEmergencia)
        {
            transform.localPosition = Vector3.Lerp(posicionOriginal, posicionObjetivo, tiempoTranscurrido / tiempoEmergencia);
            tiempoTranscurrido += Time.deltaTime;
            yield return null; // Espera hasta el siguiente frame
        }

        // Asegúrate de que llegue a la posición final
        transform.localPosition = posicionObjetivo;

        // Espera un tiempo antes de esconder los picos nuevamente
        yield return new WaitForSeconds(tiempoBajo);

        // Mueve los picos de regreso a la posición original
        tiempoTranscurrido = 0f;
        while (tiempoTranscurrido < tiempoEmergencia)
        {
            transform.localPosition = Vector3.Lerp(posicionObjetivo, posicionOriginal, tiempoTranscurrido / tiempoEmergencia);
            tiempoTranscurrido += Time.deltaTime;
            yield return null; // Espera hasta el siguiente frame
        }

        // Asegúrate de que vuelva a la posición original
        transform.localPosition = posicionOriginal;
        activado = false; // Marca que los picos están inactivos nuevamente
    }
}
