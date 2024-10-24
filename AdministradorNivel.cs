using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorNivel : MonoBehaviour
{
    public GameObject muroBloqueo;  // El muro que bloquear� la salida
    private int botonesActivados = 0;
    public int totalBotones = 3;  // Cu�ntos botones deben activarse

    // M�todo que se llamar� cada vez que se active un bot�n
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
        Debug.Log("�Todos los botones activados! El muro ha sido destruido.");
    }
}