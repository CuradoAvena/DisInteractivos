using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaActivacion : MonoBehaviour
{

    public GameObject laberintoAnterior; // Asigna el laberinto anterior en el Inspector
    public GameObject laberintoNuevo; // Asigna el nuevo laberinto en el Inspector
    public GameObject laberintoFinal;
    public Collider zonaActivacionFinal;
    private void Start()
    {
        // Asegúrate de que los laberintos estén desactivados al inicio
        laberintoAnterior.SetActive(true); // Activar el laberinto inicial
        laberintoNuevo.SetActive(false); // Asegurarse de que el nuevo laberinto esté desactivado
        laberintoFinal.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pelota"))
        {
            // Desactiva el laberinto anterior y activa el nuevo
            laberintoAnterior.SetActive(false);
            laberintoNuevo.SetActive(true);


            Debug.Log("Laberinto activado!");

            StartCoroutine(VerificarActivacionFinal(other));
        }
    }

    private IEnumerator VerificarActivacionFinal(Collider pelota)
    {
        // Espera hasta que la pelota entre en la zona de activación final
        while (true)
        {
            if (zonaActivacionFinal.bounds.Contains(pelota.transform.position))
            {
                laberintoNuevo.SetActive(false); // Desactiva el laberinto nuevo
                laberintoFinal.SetActive(true); // Activa el laberinto final
                Debug.Log("Laberinto final activado!");
                break; // Sale del bucle
            }
            yield return null; // Espera un frame antes de verificar nuevamente
        }
    }
}
