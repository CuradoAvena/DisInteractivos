using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorNivel : MonoBehaviour
{
    public GameObject muroBloqueo;  // El muro que bloqueará la salida
    private int botonesActivados = 0;
    public int totalBotones = 3;  // Cuántos botones deben activarse

    // Método que se llamará cada vez que se active un botón
    public void BotonActivado()
    {
        botonesActivados++;
        if (botonesActivados >= totalBotones)
        {
            DestruirMuro();
        }
    }

    void DestruirMuro()
    {
        // Destruir el muro cuando se activen todos los botones
        Destroy(muroBloqueo);
        Debug.Log("¡Todos los botones activados! El muro ha sido destruido.");
    }
}