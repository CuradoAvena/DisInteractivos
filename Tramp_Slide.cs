using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tramp_Slide : MonoBehaviour
{
    public float alturaEmergencia = 1.0f; // Altura a la que emergen los picos
    public float tiempoEmergencia = 0.5f;  // Tiempo que tarda en emerger
    public float tiempoBajo = 1.0f;         // Tiempo que permanecen arriba antes de volver a esconderse

    private Vector3 posicionOriginal;       // Posici�n original de los picos
    private bool activado = false;          // Controla si los picos est�n activos

    private void Start()
    {
        // Guarda la posici�n original
        posicionOriginal = transform.localPosition;
    }

    public void EmergerPicos()
    {
        if (!activado)
        {
            activado = true; // Marca que los picos est�n activados
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

        // Aseg�rate de que llegue a la posici�n final
        transform.localPosition = posicionObjetivo;

        // Espera un tiempo antes de esconder los picos nuevamente
        yield return new WaitForSeconds(tiempoBajo);

        // Mueve los picos de regreso a la posici�n original
        tiempoTranscurrido = 0f;
        while (tiempoTranscurrido < tiempoEmergencia)
        {
            transform.localPosition = Vector3.Lerp(posicionObjetivo, posicionOriginal, tiempoTranscurrido / tiempoEmergencia);
            tiempoTranscurrido += Time.deltaTime;
            yield return null; // Espera hasta el siguiente frame
        }

        // Aseg�rate de que vuelva a la posici�n original
        transform.localPosition = posicionOriginal;
        activado = false; // Marca que los picos est�n inactivos nuevamente
    }
}
